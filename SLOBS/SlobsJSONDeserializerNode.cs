using Warudo.Core.Graphs;
using Warudo.Core.Attributes;

using SLOBSharp.Client;
using SLOBSharp.Client.Requests;
using SLOBSharp.Client.Responses;

using System.Collections.Generic;

using Newtonsoft.Json;



namespace SLOBS {
    [NodeType(
    Id = nameof(SlobsJSONDeserializerNode),
    Title = "Deserialize SLOBS response",
    Category ="SLOBS")] 
    public class SlobsJSONDeserializerNode : Node {
        public enum SlobsType {
            Scene, 
            SceneItem,
            AudioSource, 
            Selection, 
            Source, 
            SceneItemFolder,
            SceneNode
        };

        [DataInput]
        public SlobsResult input;

        [DataInput]
        public SlobsType type;

        public bool isNotScene() {
            return type != SlobsType.Scene;
        }

        [HiddenIf(nameof(isNotScene))]
        [DataOutput]
        public string Id() { return input.Id; } 

        [HiddenIf(nameof(isNotScene))]
        [DataOutput]
        public string Name() { return input.Name; } 

        [HiddenIf(nameof(isNotScene))]
        [DataOutput]
        public SlobsNode[] Nodes() { return input.Nodes.ToArray(); } 









        public bool isNotSceneItem() {
            return type != SlobsType.Scene;
        }

        /*[HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public string Id() { return input.Input; } */

        /*[HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public string Locked() { return input.Locked; } */

        /*[HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public string Name() { return input.Name; } */

        /*[HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public string NodeId() { return input.NodeId; } */

        /*[HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public string ParentId() { return input.ParentId; } */

        /*
        [HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public string RecordingVisible() { return input.RecordingVisible; } 

        [HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public string SceneId() { return input.SceneId; } 

        [HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public string SceneItemId() { return input.SceneItemId; } 

        [HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public string SourceId() { return input.SourceId; } 

        [HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public string StreamVisible() { return input.StreamVisible; } 

        [HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public Transform Transform() { return input.Transform; } 

        [HiddenIf(nameof(isNotSceneItem))]
        [DataOutput]
        public bool Visible() { return input.Visible; } 
        */
    }
} 