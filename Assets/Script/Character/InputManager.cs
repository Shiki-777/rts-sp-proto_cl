using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InputManager : MonoBehaviour {

    // ナビメッシュエージェント関連（経路）
    private NavMeshAgent agent;
    private RaycastHit hit;
    private Ray ray;

    // アニメーター
    private Animator animator;

    // アクティブフラグ。アクティブ時のみ移動ができる
    private bool isActive = false;
    public bool IsActive
    {
        get
        {
            return isActive;
        }
        set
        {
            isActive = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        // オブジェクトのナビメッシュエージェントを取得
        agent = GetComponent<NavMeshAgent>();

        // オブジェクトのアニメーターを取得
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        // キャラがアクティブじゃなければ中止
        if (isActive == false) return;

        // 右クリックした時にキャラが待機中だったら移動させる
        if (Input.GetMouseButtonDown(1) && animator.GetBool("Locomotion") == false)
        {
            // マウスの位置からRayを発射する
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            // Rayがオブジェクトに当たったらその座標まで移動する
            if (Physics.Raycast(ray, out hit, 100f))
            {
                // その場所に、Nav Mesh Agentをアタッチしたオブジェクトを移動させる
                agent.SetDestination(hit.point);

                // "Lcomotion"アニメーションに遷移（走る）
                animator.SetBool("Locomotion", true);
            }
        }

        // 目的地とプレイヤーとの距離が1以下、かつ、移動中だったら停止する
        if (Vector3.Distance(hit.point, transform.position) < 1.0f && animator.GetBool("Locomotion"))
        {
            // "Lcomotion"アニメーションから抜け出す（アイドルに戻る）
            animator.SetBool("Locomotion", false);
            isActive = false;

            // アクティブマークを非表示にする
            GameObject activeMark = GameObject.Find("ActiveMark");
            activeMark.SetActive(false);
        }
    }

}