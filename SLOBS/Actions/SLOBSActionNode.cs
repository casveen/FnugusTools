using Warudo.Core.Graphs;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Plugins.Core.Assets;

using System.Collections.Generic;

using System;
using Cysharp.Threading.Tasks;

using UnityEngine;
using System.Collections;

using SLOBSharp.Client;

namespace SLOBSAction {
    enum Resource {
        AudioService,
        NotificationsService,
        PerformanceService,
        SceneCollectionsService,
        ScenesService,
        SelectionService,
        SourcesService,
        StreamingService,
        TransitionsService
    }

    public class SLOBSActionNode : Node {
        protected SlobsPipeClient client = new("slobs"); //our client

        [FlowOutput]
        public Continuation Exit;

        [FlowOutput]
        public Continuation OnSuccess;

        [FlowOutput]
        public Continuation OnError;

        public string FirstCharToLowerCase(string str) {
            if ( !string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
                return char.ToLower(str[0]) + str[1..];
            return str; 
        } 

    }
}