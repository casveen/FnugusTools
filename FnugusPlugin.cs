using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Events;
using Warudo.Core.Plugins;
using Warudo.Plugins.Core.Mixins;
using SLOBSharp.Client;

public class FnugusPlugin : Plugin {
    private const string ToolbarIconConnected = "<svg viewBox=\"0 0 24 24\" role=\"img\" xmlns=\"http://www.w3.org/2000/svg\"><g id=\"SVGRepo_bgCarrier\" stroke-width=\"2.648\"></g><g id=\"SVGRepo_tracerCarrier\" stroke-linecap=\"round\" stroke-linejoin=\"round\"></g><g id=\"SVGRepo_iconCarrier\"><title>OBS Studio icon</title><path fill=\"currentColor\" d=\"M12,24C5.383,24,0,18.617,0,12S5.383,0,12,0s12,5.383,12,12S18.617,24,12,24z M12,1.109 C5.995,1.109,1.11,5.995,1.11,12C1.11,18.005,5.995,22.89,12,22.89S22.89,18.005,22.89,12C22.89,5.995,18.005,1.109,12,1.109z M6.182,5.99c0.352-1.698,1.503-3.229,3.05-3.996c-0.269,0.273-0.595,0.483-0.844,0.78c-1.02,1.1-1.48,2.692-1.199,4.156 c0.355,2.235,2.455,4.06,4.732,4.028c1.765,0.079,3.485-0.937,4.348-2.468c1.848,0.063,3.645,1.017,4.7,2.548 c0.54,0.799,0.962,1.736,0.991,2.711c-0.342-1.295-1.202-2.446-2.375-3.095c-1.135-0.639-2.529-0.802-3.772-0.425 c-1.56,0.448-2.849,1.723-3.293,3.293c-0.377,1.25-0.216,2.628,0.377,3.772c-0.825,1.429-2.315,2.449-3.932,2.756 c-1.244,0.261-2.551,0.059-3.709-0.464c1.036,0.302,2.161,0.355,3.191-0.011c1.381-0.457,2.522-1.567,3.024-2.935 c0.556-1.49,0.345-3.261-0.591-4.54c-0.7-1.007-1.803-1.717-3.002-1.969c-0.38-0.068-0.764-0.098-1.148-0.134 c-0.611-1.231-0.834-2.66-0.528-3.996L6.182,5.99z\"></path></g></svg><i style=\"position: absolute; background: rgb(36,161,72); width: 6px; height: 6px; border-radius: 3px;\"></i>";
    private const string ToolbarIconNotConnected = "<svg viewBox=\"0 0 23.75 23.75\" role=\"img\" xmlns=\"http://www.w3.org/2000/svg\"><g id=\"SVGRepo_bgCarrier\" stroke-width=\"2.648\"></g><g id=\"SVGRepo_tracerCarrier\" stroke-linecap=\"round\" stroke-linejoin=\"round\"></g><g id=\"SVGRepo_iconCarrier\"><title>OBS Studio icon</title><path fill=\"currentColor\" d=\"M12,24C5.383,24,0,18.617,0,12S5.383,0,12,0s12,5.383,12,12S18.617,24,12,24z M12,1.109 C5.995,1.109,1.11,5.995,1.11,12C1.11,18.005,5.995,22.89,12,22.89S22.89,18.005,22.89,12C22.89,5.995,18.005,1.109,12,1.109z M6.182,5.99c0.352-1.698,1.503-3.229,3.05-3.996c-0.269,0.273-0.595,0.483-0.844,0.78c-1.02,1.1-1.48,2.692-1.199,4.156 c0.355,2.235,2.455,4.06,4.732,4.028c1.765,0.079,3.485-0.937,4.348-2.468c1.848,0.063,3.645,1.017,4.7,2.548 c0.54,0.799,0.962,1.736,0.991,2.711c-0.342-1.295-1.202-2.446-2.375-3.095c-1.135-0.639-2.529-0.802-3.772-0.425 c-1.56,0.448-2.849,1.723-3.293,3.293c-0.377,1.25-0.216,2.628,0.377,3.772c-0.825,1.429-2.315,2.449-3.932,2.756 c-1.244,0.261-2.551,0.059-3.709-0.464c1.036,0.302,2.161,0.355,3.191-0.011c1.381-0.457,2.522-1.567,3.024-2.935 c0.556-1.49,0.345-3.261-0.591-4.54c-0.7-1.007-1.803-1.717-3.002-1.969c-0.38-0.068-0.764-0.098-1.148-0.134 c-0.611-1.231-0.834-2.66-0.528-3.996L6.182,5.99z\"></path></g></svg>";
    private static readonly ConcurrentQueue<Action> _actions = new();

    [Mixin(1)]
    public ToolbarItemMixin ToolbarItem;

    public override void OnPreUpdate() {
        base.OnPreUpdate();
    }

    protected static void SubscribeToEvents<T>(T target) {
        foreach(var @event in target.GetType().GetEvents())
        {
            var handler = GetHandlerFor(@event);
            @event.AddEventHandler(target, handler);
        }
    }

    static MethodInfo? genericHandlerMethod = typeof(FnugusPlugin).GetMethod("Handler", BindingFlags.Static | BindingFlags.NonPublic);
    static MethodInfo? genericBroadcast = typeof(FnugusPlugin).GetMethod("Broadcast", BindingFlags.Static | BindingFlags.NonPublic);

    private static Delegate GetHandlerFor(EventInfo eventInfo)
    {
        var eventArgsType = eventInfo.EventHandlerType?.GetMethod("Invoke")?.GetParameters()[1]?.ParameterType;
        if(eventArgsType is null)
        {
            throw new ApplicationException("Couldn't get event args type from eventInfo.");
        }
        var handlerMethod = genericHandlerMethod?.MakeGenericMethod(eventArgsType);
        if(handlerMethod is null)
        {
            throw new ApplicationException("Couldn't get handlerMethod from genericHandlerMethod.");
        }

        if (eventArgsType.Namespace == "System") {
          return Delegate.CreateDelegate(typeof(EventHandler), handlerMethod);
        }
        return Delegate.CreateDelegate(typeof(EventHandler<>).MakeGenericType(eventArgsType), handlerMethod);
    }

    private static void Handler<e>(object? sender, e args)
    {
      if(args.GetType().IsSubclassOf(typeof(Event)))
      {
        _actions.Enqueue(() => {
          genericBroadcast.MakeGenericMethod(args.GetType()).Invoke(sender, new object[]{args});
        });
      }
    }

    private static void Broadcast<T>(T e) where T : Warudo.Core.Events.Event => Context.EventBus.Broadcast<T>(e);
}
