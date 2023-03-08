using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefenceBehaviour : StateMachineBehaviour
{
    [SerializeField] PlayerStatusSO playerStatusSO;
    // アニメーション開始時に実行される：Start関数のようなもの
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 速度を0にしたい
        animator.GetComponent<PlayerManager>().MoveSpeed = 0;
    }

    // アニメーション中に実行される：Update関数のようなもの
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // アニメーションの遷移が行われるとき：
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 速度を元に戻したい
        animator.GetComponent<PlayerManager>().MoveSpeed = playerStatusSO.moveSpeed;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}