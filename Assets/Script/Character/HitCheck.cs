using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour {

    private static float SPEED = 3.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // 他のオブジェクトと衝突した時に行う処理
    private void OnCollisionEnter(Collision collision)
    {
        // 衝突対象がユニットだった場合はヒット処理を行う
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.name);

            // 親オブジェクトを取得
            GameObject parent = collision.gameObject.transform.parent.gameObject;

            Vector3 force = new Vector3();

            // 前方コリジョンと衝突
            if (collision.gameObject.name == "CollisionFront")
            {
                force = new Vector3(0.0f, 0f, -SPEED);
            }

            // 後方コリジョンと衝突
            if (collision.gameObject.name == "CollisionBack")
            {
                force = new Vector3(0.0f, 0.0f, SPEED);
            }

            // 左コリジョンと衝突
            if (collision.gameObject.name == "CollisionLeft")
            {
                force = new Vector3(SPEED, 0.0f, 0.0f);
            }

            // 右コリジョンと衝突
            if (collision.gameObject.name == "CollisionRight")
            {
                force = new Vector3(-SPEED, 0.0f, 0.0f);

            }

            parent.transform.Translate(force);

            // 対象者のヒットアニメーションを再生
            Animator animator = parent.GetComponent<Animator>();
            animator.SetBool("Jump", true);

            /*
                        // 対象者のヒットアニメーションを再生
                        Animator animator = collision.gameObject.GetComponent<Animator>();
                        animator.SetBool("Jump", true);

                        // 対象者のノックバックを行う
                        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

                        Vector3 normal = new Vector3();
                        normal = -collision.contacts[0].normal;
                        rb.AddForce(normal * 100);

                        Debug.Log(collision.gameObject.name + " : " + normal);
                        Debug.Break();
            */

        }

    }

}
