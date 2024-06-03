using Warudo.Core.Graphs;
using Warudo.Core.Attributes;

using SLOBSharp.Client;
using SLOBSharp.Client.Requests;
using SLOBSharp.Client.Responses;

using System.Collections.Generic;

using Newtonsoft.Json;



namespace SLOBS {
    [NodeType(
    Id = nameof(SlobsJSONDeserializeNodeNode),
    Title = "Deserialize SLOBS Node",
    Category ="SLOBS")] 
    public class SlobsJSONDeserializeNodeNode : Node {
        [DataInput]
        public SlobsNode input;

        [DataOutput]
        public string Id() { return input.Id; } 


        [DataOutput]
        public bool Locked() { return input.Locked??false; }


        [DataOutput]
        public string Name() { return input.Name; }

        /*
        [DataOutput]
        public string NodeId() { return input.NodeId; }
        */

        [DataOutput]
        public string ParentId() { return input.ParentId; }

        /*
        [DataOutput]
        public string RecordingVisible() { return input.RecordingVisible; } 
*/
        [DataOutput]
        public string SceneId() { return input.SceneId; } 

        [DataOutput]
        public string SceneItemId() { return input.SceneItemId; } 

        [DataOutput]
        public string SourceId() { return input.SourceId; } 

        /*[DataOutput]
        public string StreamVisible() { return input.StreamVisible; } */

        [DataOutput]
        public Transform Transform() { return input.Transform; } 

        [DataOutput]
        public bool Visible() { return input.Visible??false; } 
    }
} 