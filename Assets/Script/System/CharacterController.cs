using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public GameObject activeMark = GameObject.Find("ActiveMark");

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

                    // アクティブマークを表示
                    activeMark.SetActive(true);
                    Vector3 position = unit.GetComponent<InputManager>().transform.position;
                    activeMark.transform.position = new Vector3(position.x, activeMark.transform.position.y, position.z);
                }
            }
        }

    }

}
