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
        // 左クリックしたときに、
        if (Input.GetMouseButtonDown(0))
        {
            // マウスの位置からRayを発射して、
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            // 物体にあたったら、
            if (Physics.Raycast(ray, out hit, 100f))
            {
                // その場所に、Nav Mesh Agentをアタッチしたオブジェクトを移動させる
                agent.SetDestination(hit.point);

                // "Lcomotion"アニメーションに遷移（走る）
                animator.SetBool("Locomotion", true);
            }
        }

        // 目的地とプレイヤーとの距離が1以下になったら、
        if (Vector3.Distance(hit.point, transform.position) < 1.0f)
        {
            // "Lcomotion"アニメーションから抜け出す（アイドルに戻る）
            animator.SetBool("Locomotion", false);
        }
    }

}