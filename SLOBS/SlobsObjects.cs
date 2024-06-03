using Warudo.Core.Graphs;
using Warudo.Core.Attributes;

using SLOBSharp.Client;
using SLOBSharp.Client.Requests;
using SLOBSharp.Client.Responses;

using System.Collections.Generic;

using Newtonsoft.Json;

namespace SLOBS {

    /////////////////
    /// TRANSFORM ///
    /////////////////
    [NodeType(
    Id = nameof(SlobsTransformDeconstructorNode),
    Title = "Deconstruct SLOBS Transform",
    Category ="SLOBS")] 
    public class SlobsTransformDeconstructorNode : Node {
        [DataInput]
        public Transform transform;


        [DataOutput]
        public Crop Crop() { return transform.Crop; }

        [DataOutput]
        public Position Position() { return transform.Position; }

        [DataOutput]
        public long Rotation() { return transform.Rotation; }

        [DataOutput]
        public Position Scale() { return transform.Scale; }
    }

        [NodeType(
    Id = nameof(SlobsTransformConstructorNode),
    Title = "Construct SLOBS Transform",
    Category ="SLOBS")] 
    public class SlobsTransformConstructorNode : Node {
        [DataOutput]
        public Transform Transform() {
            Transform t = new Transform();
            t.Crop=Crop;
            t.Position=Position;
            t.Rotation=Rotation;
            t.Scale=Scale;
            return t;
        }

        [DataInput]
        public Crop Crop;

        [DataInput]
        public Position Position;

        [DataInput]
        public long Rotation;

        [DataInput]
        public Position Scale;
    }

    ////////////////
    ///   CROP   ///
    ////////////////
    [NodeType(
    Id = nameof(SlobsCropDeconstructorNode),
    Title = "Deconstruct SLOBS Crop",
    Category ="SLOBS")] 
    public class SlobsCropDeconstructorNode : Node {
        [DataInput]
        public Crop crop;

        [DataOutput]
        public long Bottom() { return crop.Bottom; }

        [DataOutput]
        public long Left() { return crop.Left; }

        [DataOutput]
        public long Right() { return crop.Right; }

        [DataOutput]
        public long Top() { return crop.Top; }
    }

    [NodeType(
    Id = nameof(SlobsCropConstructorNode),
    Title = "Construct SLOBS Crop",
    Category ="SLOBS")] 
    public class SlobsCropConstructorNode : Node {
        [DataOutput]
        public Crop Crop() {
            Crop c = new Crop();
            c.Bottom=Bottom;
            c.Left=Left;
            c.Right=Right;
            c.Top=Top;
            return c;
        }

        [DataInput]
        public long Bottom;

        [DataInput]
        public long Left;

        [DataInput]
        public long Right;

        [DataInput]
        public long Top;
    }



    ////////////////
    /// POSITION ///
    ////////////////
    [NodeType(
    Id = nameof(SlobsPositionDeconstructorNode),
    Title = "Deconstruct SLOBS Position",
    Category ="SLOBS")] 
    public class SlobsPositionDeconstructorNode : Node {
        [DataInput]
        public Position position;

        [DataOutput]
        public double X() { return position.X; }

        [DataOutput]
        public double Y() { return position.Y; }
    }

    [NodeType(
    Id = nameof(SlobsPositionConstructorNode),
    Title = "Construct SLOBS Position",
    Category ="SLOBS")] 
    public class SlobsPositionConstructorNode : Node {
        [DataOutput]
        public Position Position() {
            Position p = new Position();
            p.X=X;
            p.Y=Y;
            return p;
        }

        [DataInput]
        public double X;

        [DataInput]
        public double Y;
    }


    
    /////////////
    /// SCENE /// FIX
    /////////////
    [NodeType(
    Id = nameof(SlobsSceneDeconstructorNode),
    Title = "Deconstruct SLOBS Scene",
    Category ="SLOBS")] 
    public class SlobsSceneDeconstructorNode : Node {
        [DataInput]
        public SlobsNode item;

        [DataOutput]
        public string Id() { return item.Id; }

        [DataOutput]
        public string Name() { return item.Name; }

        [DataOutput] //fix
        public string SlobsNode() { return null; }
    }

    /////////////////
    /// SCENENODE ///
    /////////////////
    [NodeType(
    Id = nameof(SlobsSceneNodeDeconstructorNode),
    Title = "Deconstruct SLOBS SceneNode",
    Category ="SLOBS")] 
    public class SlobsSceneNodeDeconstructorNode : Node {
        [DataInput]
        public SlobsNode item;

        [DataOutput]
        public string Id() { return item.Id; }

        /*[DataOutput]
        public string NodeId() { return item.NodeId; }*/

        [DataOutput]
        public string ParentId() { return item.ParentId; }

        [DataOutput]
        public string SceneId() { return item.SceneId; }

        [DataOutput]
        public SceneNodeType SceneNodeType() { return item.SceneNodeType; }
    }



    //////////////////////
    /// SCENEITEMMODEL ///
    //////////////////////
    [NodeType(
    Id = nameof(SlobsSceneItemDeconstructorNode),
    Title = "Deconstruct SLOBS SceneItem",
    Category ="SLOBS")] 
    public class SlobsSceneItemDeconstructorNode : SlobsSceneNodeDeconstructorNode {
        /*[DataInput]
        public SceneItem item;*/

        /*[DataOutput]
        public string[] ChildrenIds() { return item.ChildrenIds; }*/

        [DataOutput]
        public bool Locked() { return item.Locked ?? false; }

        [DataOutput]
        public string Name() { return item.Name; }

        /*[DataOutput]
        public bool RecordingVisible() { return item.RecordingVisible; }*/

        [DataOutput]
        public string SceneItemId() { return item.SceneItemId; }

        [DataOutput]
        public string SourceId() { return item.SourceId; }

        /*[DataOutput]
        public bool StreamVisible() { return item.StreamVisible; }*/

        [DataOutput]
        public Transform Transform() { return item.Transform; }

        [DataOutput]
        public bool Visible() { return item.Visible ?? false; }
    }

    ///////////////////////
    /// SCENEITEMFOLDER ///
    ///////////////////////
    [NodeType(
    Id = nameof(SlobsSceneItemFolderDeconstructorNode),
    Title = "Deconstruct SLOBS SceneItemFolder",
    Category ="SLOBS")] 
    public class SlobsSceneItemFolderDeconstructorNode : SlobsSceneNodeDeconstructorNode {
        /*[DataInput]
        public SceneItem item;*/

        /*[DataOutput]
        public string[] ChildrenIds() { return item.ChildrenIds; }*/
    }




    ///////////////////
    /// AudioSource ///
    ///////////////////
    [NodeType(
    Id = nameof(SlobsAudioSourceDeconstructorNode),
    Title = "Deconstruct SLOBS AudioSource",
    Category ="SLOBS")] 
    public class SlobsAudioSourceDeconstructorNode : Node {
        [DataInput]
        public SlobsNode item;

        [DataOutput]
        public int AudioMixers() { return 0; }

        [DataOutput]
        public string Fader() { return ""; }

        [DataOutput]
        public bool ForceMono() { return false; }

        [DataOutput]
        public bool MixerHidden() { return false; }

        // impl //
        [DataOutput]
        public bool MonitoringType() { return false; } // obs.EMonitoringType

        [DataOutput]
        public bool Muted() { return false; }

        [DataOutput]
        public string Name() { return ""; }

        [DataOutput]
        public string SourceId() { return ""; }

        [DataOutput]
        public int SyncOffset() { return 0; }
    }

    /////////////
    /// Fader ///
    /////////////
    [NodeType(
    Id = nameof(SlobsFaderDeconstructorNode),
    Title = "Deconstruct SLOBS Fader",
    Category ="SLOBS")] 
    public class SlobsFaderDeconstructorNode : Node {
        [DataInput]
        public SlobsNode item;

        [DataOutput]
        public int Db() { return 0; }

        [DataOutput]
        public int Deflection() { return 0; }

        [DataOutput]
        public int Mul() { return 0; }
    }

    /////////////////
    /// SELECTION ///
    /////////////////
    /*[NodeType(
    Id = nameof(SlobsSceneDeconstructorNode),
    Title = "Deconstruct SLOBS Scene",
    Category ="SLOBS")] 
    public class SlobsSceneDeconstructorNode : Node {
        [DataInput]
        public SlobsNode item;

        [DataOutput]
        public string SceneId() { return item.SceneId; }
    }*/


}