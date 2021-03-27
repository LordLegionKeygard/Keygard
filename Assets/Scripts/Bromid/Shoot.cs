using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : StateMachineBehaviour
{
    [SerializeField] Bromid bromid;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bromid = GameObject.FindGameObjectWithTag("Bromid").GetComponent<Bromid>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bromid.AttackShoot();
    }
}
