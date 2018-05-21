using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    [SerializeField]
    private GameObject NormalCamera;       //   通常時に使用するカメラ
    [SerializeField]
    private GameObject PlayerCamera;       //   プレイヤーがカメラ使用時の別カメラ

	// Use this for initialization
	void Start () {
        //  プレイヤーがカメラ使用時のカメラを非アクティブにする
        PlayerCamera.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        //  スペースキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  それぞれのカメラのアクティブ状態を反転する
            if (NormalCamera.activeSelf)
            {
                NormalCamera.SetActive(false);
                PlayerCamera.SetActive(true);
            }
            else
            {
                NormalCamera.SetActive(true);
                PlayerCamera.SetActive(false);
            }

        }
	}
}
