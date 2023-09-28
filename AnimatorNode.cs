using Warudo.Core.Graphs;
using Warudo.Core.Attributes;
using Warudo.Core.Data;
using Warudo.Plugins.Core.Assets;

using System.Collections.Generic;

using System;
using Cysharp.Threading.Tasks;

using UnityEngine;
using System.Collections;

namespace AnimatorNode {
    [NodeType(
    Id = nameof(AnimatorNode), // Must be unique. Generate one at https://guidgenerator.com/
    Title = "Animator",
    Category ="Fnugus")]
    public class AnimatorNode : Node {
        [DataInput]
        public GameObjectAsset AnimatedAsset;

        [DataInput]
        public bool UseUpmostParent = false;


        public class Awaiter:MonoBehaviour {

        }


         protected override void OnCreate() {
            base.OnCreate();


            Watch(nameof(AnimatedAsset), () => {
                if (AnimatedAsset!=null) {
                    SetupInputPorts();
                    
                    Broadcast();
                }
            });
         }

        [FlowOutput]
        public Continuation Exit;


        IEnumerator ExecuteAfterTime(float time, Action task)
{
    yield return new WaitForSeconds(time);

    task();
}
        

        public void SetupInputPorts() {
            /*Animator[] allAnimators = Animator.FindObjectsByType<Animator>(FindObjectsSortMode.None);
            Debug.Log("Found " + allAnimators.Length + " animators");
            foreach (Animator animator in allAnimators) {
                Debug.Log(animator);
                Debug.Log(animator.name);
                Debug.Log(animator.gameObject);
            }*/



            Debug.Log(AnimatedAsset.GameObject.name);
            Debug.Log("Setting up input ports");
            FlowInputPortCollection.GetPorts().Clear();
            if (UseUpmostParent) {
                return;
            } else {
                //find all animators
                Debug.Log("Getting animators");
                //Animator[] animators = AnimatedAsset.GameObject.GetComponents<Animator>();
                Animator[] animators = Animator.FindObjectsByType<Animator>(FindObjectsSortMode.None);
                
                Debug.Log("Found " + animators.Length + " animators");
                foreach (Animator animator in animators) {
                    Debug.Log(animator);
                    foreach (AnimatorControllerParameter parameter in animator.parameters) {
                        string inputName = animator.name + ":" + parameter.name;
                        AddFlowInputPort(
                            inputName, 
                            () => {
                                
                                animator.Update(0f);
                                animator.ResetTrigger(parameter.name);
                                animator.SetTrigger(parameter.name);
                                animator.Update(1f);

                                Awaiter awaiter = AnimatedAsset.GameObject.AddComponent<Awaiter>();
                                awaiter.StartCoroutine(ExecuteAfterTime(0.5f,() => {
                                    // Code to execute after the delay
                                    animator.Update(2f);
                                    Awaiter.Destroy(awaiter);
                                }));
                                
                                //animator.Update(1f);
                                
                                //animator.Update(0f);
                                //animator.WriteDefaultValues();
                                //animator.Update(0f);
                                

                                
                                return nameof(Exit);
                            },
                            new FlowInputProperties {
                                label = inputName,
                                description = ""
                            }
                        );
                    }
                }
            }
            Broadcast();
        }





        public void SetupOutputPorts() { 
            /*
            DataOutputPortCollection.GetPorts().Clear();
            Animator[] animators = Animator.FindObjectsByType<Animator>(FindObjectsSortMode.None);
            foreach (Animator animator in animators) {
                Debug.Log(animator);
                foreach (AnimatorControllerParameter parameter in animator.parameters) {
                    string inputName = animator.name + ":" + parameter.name;
                    AddDataOutputPort(
                        inputName, 
                        () => {
                            //animator.Update(0f);
                            animator.SetTrigger(parameter.name);
                            //animator.Update(0f);
                            animator.WriteDefaultValues();
                            //animator.Update(0f);
                            return nameof(Exit);
                        },
                        new FlowInputProperties {
                            label = inputName,
                            description = ""
                        }
                    );
                }
            }*/
        }
    }
}