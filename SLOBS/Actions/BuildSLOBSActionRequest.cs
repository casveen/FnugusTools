using Warudo.Core.Graphs;
using Warudo.Core.Attributes;

using SLOBSharp.Client;
using SLOBSharp.Client.Requests;
using SLOBSharp.Client.Responses;

using System.Collections.Generic;

using Newtonsoft.Json;

namespace SLOBSAction {
    [NodeType(
    Id = nameof(BuildSLOBSActionNode),
    Title = "Build SLOBS Action",
    Category ="SLOBS")] 
    public class BuildSLOBSActionNode : SLOBSActionNode {
        


        [DataInput]
        public string service = "";

        [DataInput]
        public string method = "";

        [DataInput]
        public string[] arguments;

        List<SlobsResult> res = new List<SlobsResult>();

        [DataOutput]
        public SlobsResult[] result() {
            return res.ToArray();
        } 

        [DataOutput]
        public string error() {
            return err;
        } 

        protected string resjson;
        protected string reqjson;
        protected string err;

        [DataOutput]
        public string resultjson() { 
            return resjson;
        } 

        [DataOutput]
        public string requestjson() {
            return reqjson;
        }

        [FlowInput]
        public Continuation Enter() {
            // Build our request
            var slobsRequestB = SlobsRequestBuilder.NewRequest()
                                                  .SetMethod(method)
                                                  .SetResource(service)
                                                  .AddArgs(arguments);
            /*if (resource != "") {
                slobsRequestB = slobsRequestB.SetResource(resource); 
            }*/
                                                  //.SetRequestId(reqId)
                                                  //.SetResource(resource) 
            var slobsRequest = slobsRequestB.BuildRequest();
            reqjson = slobsRequest.ToJson(); 

            // Issue the request
            client.ExecuteRequestAsync(slobsRequest).ContinueWith( (response) => {
                err = "";
                //there should only be one SlobsResult, but looped for good measure...
                var result = response.Result; //awaits here
                //err = result.Error;
                resjson = JsonConvert.SerializeObject(result);
                res.Clear();
                //resjson.Clear();


                foreach (SlobsResult sr in result.Result) { //Result of task, Result of resulting request, blegh
                    res.Add( sr );
                } 
            });

            return Exit;
        }    
    }
}