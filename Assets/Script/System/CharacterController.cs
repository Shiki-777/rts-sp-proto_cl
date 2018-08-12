using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    private RaycastHit hit;
    private Ray ray;

    private GameObject unit = null;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // 左クリックしたときに、
        if (Input.GetMouseButtonDown(0))
        {
            // マウスの位置からRayを発射する
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Rayがプレイアブルキャラクターに当たったらそのキャラをアクティブにする
            if (Physics.Raycast(ray, out hit, 100f))
            {
                // Rayが当たったオブジェクトを取得
                unit = hit.collider.gameObject;

                // プレイアブルキャラクターだったらアクティブにする
                if(unit.tag == "Player")
                {
                    unit.GetComponent<InputManager>().IsActive = true;
                }
            }
        }

    }

}
