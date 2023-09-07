using UnityEngine;
using System.Collections;
using Warudo.Core.Attributes;
using Warudo.Core.Graphs;
using Warudo.Core.Scenes;
using Warudo.Plugins.Core.Assets;
using Warudo.Plugins.Core.Assets.Character;
using Warudo.Plugins.Core.Assets.Prop;
using Warudo.Core.Data.Models;
using Animancer;


using Warudo.Plugins.Core.Assets.Utility;
using Warudo.Plugins.Core.Assets.Cinematography;

using System;
//using Cysharp.Threading.Tasks;
using Warudo.Core;
using Warudo.Core.Data;
using RootMotion.Dynamics;
using Warudo.Core.Utils;
using Warudo.Core.Localization;
using Warudo.Plugins.Core;
using Warudo.Plugins.Core.Utils;
using Warudo.Plugins.Interactions.Mixins;
using Object = UnityEngine.Object;




namespace GameObjectExtenders {
    [NodeType(
        Id = nameof(DestroyGameObjectNode), // Must be unique. Generate one at https://guidgenerator.com/
        Title = "Destroy GameObject",
        Category ="Fnugus")]
    public class DestroyGameObjectNode : Node {
        [DataInput]
        public GameObject ToDestroy;

        [DataInput]
        public float InTime = 0f;


        [FlowInput]
        public Continuation Enter() {
            Object.Destroy(ToDestroy, InTime);
            return Exit;
        }

        [FlowOutput]
        public Continuation Exit;



    }
}