using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefenceBehaviour : StateMachineBehaviour
{
    [SerializeField] PlayerStatusSO playerStatusSO;
    // �A�j���[�V�����J�n���Ɏ��s�����FStart�֐��̂悤�Ȃ���
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ���x��0�ɂ�����
        animator.GetComponent<PlayerManager>().MoveSpeed = 0;
    }

    // �A�j���[�V�������Ɏ��s�����FUpdate�֐��̂悤�Ȃ���
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // �A�j���[�V�����̑J�ڂ��s����Ƃ��F
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ���x�����ɖ߂�����
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