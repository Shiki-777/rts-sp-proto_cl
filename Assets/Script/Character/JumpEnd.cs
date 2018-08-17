using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnd : StateMachineBehaviour {

    // Jumpアニメーション終了時に行う処理
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 着地したらフラグをOFFにする
        animator.SetBool("Jump", false);
	
	}

}
