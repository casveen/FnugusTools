/*using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Warudo.Core;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Core.Events;
using Warudo.Core.Plugins;
using Warudo.Core.Graphs;
using Warudo.Plugins.Core.Mixins;
using SLOBSharp.Client;

namespace fnugus.slobsevents {
    [PluginType(
        Id = "com.fnugus.slobs", 
        Name = "SL Events", 
        Version = "0.0.1", 
        Author = "Fnugus", 
        Description = "SL Nodes")]
        //NodeTypes = new[] {
            //typeof(OnCurrentProgramSceneChangedNode),
        //}
        
    public class SLOBSPlugin : FnugusPlugin {
        [DataInput(-900)]
        [Label("Pipe")]
        private string Pipe = "slobs";
        
        new SLOBSharp.Client.SlobsPipeClient client = new("slobs");*/

        /*protected NodeTypeMeta registerConstructorNode(string id, Type type) {
            //create meta, then put it in registry

            var NodeConstructorMeta = new NodeTypeMeta {
                Id = id,
                Type = type
            };
            var NodeDeconstructorMeta = new NodeTypeMeta {
                Id = id,
                Type = type
            };
            var label = "aaa";
            foreach (var fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) {
                var NodeConstructorTypeMeta = new ReflectedDataInputPortMeta(
                    fieldInfo,
                    new DataInputProperties {
                        transient = false,
                        order = 1, //i,
                        hidden = false,
                        disabled = false,
                        label = label,
                        description = "123", //description,
                        sectionTitle = "456", //sectionTitle,
                        alwaysHidden = false,
                        alwaysDisabled = false
                    },
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );//DataInputPort.GetReflectionMeta(fieldInfo);

    
                var NodeDeconstructorTypeMeta = new ReflectedDataOutputPortMeta(
                    null,
                    //new MethodInfo(),
                    new DataOutputProperties {
                        order = 0,
                        label ="bbb",
                        description = "rgrt",
                        sectionTitle = "werøfjn"
                    },
                    null,  
                    null, 
                    null, 
                    null
                );
                //if (dataInputPortTypeMeta != null) {
                // NodeConstructorMeta.DataInputs.Add(NodeConstructorTypeMeta);
                    //NodeDeconstructorMeta.DataOutputs.Add(NodeDeconstructorTypeMeta);
                //}
            }

            Context.NodeTypeRegistry.GetRegisteredTypes()[id]=NodeConstructorMeta;

            return null;
        }*/

        /*protected override void OnCreate() {
            base.OnCreate();*/

            /*Watch<string>(nameof(websocketPassword), (from, to) => {
                websocketPassword = new string('*', to.Length);
                BroadcastDataInput(nameof(websocketPassword));
            });*/
            //ToolbarItem.SetTooltip("Disconnected From OBS Websocket");
            //ToolbarItem.SetIcon(ToolbarIconNotConnected);

            //registerConstructorNode("DING", typeof(GRET));





       /*     ToolbarItem.OnTrigger = () => Context.Service.NavigateToPlugin(Type.Id, null);
            ToolbarItem.SetEnabled(true);

            SubscribeToEvents(client);
        }

        protected override void OnDestroy() {
            base.OnDestroy();
        }

        public override void OnPreUpdate() {
            base.OnPreUpdate();
        }
    }

    class GRET {
                    public int rrr;
                    public string abaga;
                }
}*/





