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

namespace Text {
    [NodeType(
        Id = nameof(MakeTextNode), // Must be unique. Generate one at https://guidgenerator.com/
        Title = "MakeText",
        Category ="Fnugus")]
    public class MakeTextNode : Node {
        [DataInput]
        public string Text;

        [DataInput]
        public Vector3 Position;

        [DataInput]
        public float CharacterSize = 0.1f;

        [DataInput]
        public int FontSize = 64;

        private GameObject LatestMadeText;

        [DataOutput]
        public GameObject TextObject() {
            return LatestMadeText;
        }

        [DataOutput]
        public Transform TextTransform() {
            return LatestMadeText?.GetComponent<Transform>();
        }



        [FlowInput]
        public Continuation Enter() {
            GameObject textObject = new GameObject();
            //textObject.AddComponent<Transform>();
            textObject.AddComponent<TextMesh>();
            TextMesh text = textObject.GetComponent<TextMesh>();
            Transform transform = textObject.GetComponent<Transform>();

            text.text = Text;
            text.characterSize = CharacterSize;
            text.fontSize = FontSize;

            transform.position = Position;
            transform.Rotate(new Vector3(0,180,0));

            LatestMadeText = textObject;

            return Exit;
        }


        [FlowOutput]
        public Continuation Exit;
    }
}