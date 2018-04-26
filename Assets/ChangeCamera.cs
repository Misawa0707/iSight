using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    [SerializeField]
    private GameObject NormalCamera;       //   通常時に使用するカメラ
    [SerializeField]
    private GameObject PlayerCamera;       //   プレイヤーがカメラ使用時の別カメラ

    private bool useCameraFlag;            //   カメラを使用しているかどうかのフラグ

    GameObject player;                     //   プレイヤーオブジェくト
    PlayerController playerScript;         //   プレイヤーのスクリプト

	// Use this for initialization
	void Start () {
        //  プレイヤーがカメラ使用時のカメラを非アクティブにする
        PlayerCamera.SetActive(false);

        //  変数の初期化処理
        useCameraFlag = false;
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

        //  スペースキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  バッテリーがあれば
            if (playerScript.Battery > 0)
            {
                //  それぞれのカメラのアクティブ状態を反転する
                if (NormalCamera.activeSelf)
                {
                    NormalCamera.SetActive(false);
                    PlayerCamera.SetActive(true);

                    //  カメラ使用のフラグをtrueにする
                    useCameraFlag = true;
                }
                else
                {
                    NormalCamera.SetActive(true);
                    PlayerCamera.SetActive(false);

                    //  カメラ使用のフラグをfalseにする
                    useCameraFlag = false;
                }
            }

        }

        //  バッテリーがなくなったらカメラの使用を止める
        if(playerScript.Battery < 0)
        {
            NormalCamera.SetActive(true);
            PlayerCamera.SetActive(false);
        }
	}
    

    //  カメラの使用状態の取得
    public bool GetCameraFlag()
    {
        return useCameraFlag;
    }
}
