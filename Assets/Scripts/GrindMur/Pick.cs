using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : StateMachineBehaviour
{
    [SerializeField] GrindMur grindMur;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        grindMur = GameObject.FindGameObjectWithTag("Grindmur").GetComponent<GrindMur>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        grindMur.Pick();
    }
}
