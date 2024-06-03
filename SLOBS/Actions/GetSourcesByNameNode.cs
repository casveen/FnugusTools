/*using Warudo.Core.Graphs;
using Warudo.Core.Attributes;

using System;
using System.Collections.Generic;

using SLOBSharp.Client;
using SLOBSharp.Client.Requests;
using SLOBSharp.Client.Responses;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace SLOBSAction {
    [NodeType(
    Id = nameof(GetSourcesByNameNode),
    Title = "Get Sources By Name",
    Category ="SLOBS")] 
    public class GetSourcesByNameNode : SLOBSActionNode {
        List<string> res= new List<string>();
        List<string> resId = new List<string>();

        [DataOutput]
        public string[] activeScene() {
            return res.ToArray();
        } 
        [DataOutput]
        public string[] resourceId() {
            return resId.ToArray();
        }

        [DataInput]
        public string sourceName=""; 

        [FlowInput]
        public Continuation Enter() {
            // Build our request
            var slobsRequest = 
                SlobsRequestBuilder.NewRequest()
                .SetMethod("getSourcesByName")
                .SetResource("SourcesService")
                .AddArgs(sourceName);
            reqjson = slobsRequest.BuildRequest().ToJson(); 

            // Issue the request
            //res.Add("bing");
            client.ExecuteRequestAsync(slobsRequest.BuildRequest()).ContinueWith( (response) => {
                res.Clear();
                resId.Clear();
                //resjson.Clear();
                var result = response.Result; //awaits here
                res.Add("post");
                // result is an array of SlobsResult, each with the result as .Result, In this cse there should be exactly one
                foreach (SlobsResult sr in result.Result) { //Result of task, Result of resulting request, blegh
                    res.Add(sr.Name);
                    resId.Add(sr.ResourceId);
                    resjson = JsonConvert.SerializeObject(sr);
                }
                
            });

            return Exit;
        }    
    }
} */