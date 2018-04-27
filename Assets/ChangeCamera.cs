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


    public GameObject Wall1;                //消える壁1～６
    public GameObject Wall2;        
    public GameObject Wall3;
    public GameObject Wall4;
    public GameObject Wall5;
    public GameObject Wall6;

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
                    Wall1.SetActive(false);
                    Wall2.SetActive(false);
                    Wall3.SetActive(false);
                    Wall4.SetActive(false);
                    Wall5.SetActive(false);
                    Wall6.SetActive(false);

                    //  カメラ使用のフラグをtrueにする
                    useCameraFlag = true;
                }
                else
                {
                    NormalCamera.SetActive(true);
                    PlayerCamera.SetActive(false);
                    Wall1.SetActive(true);
                    Wall2.SetActive(true);
                    Wall3.SetActive(true);
                    Wall4.SetActive(true);
                    Wall5.SetActive(true);
                    Wall6.SetActive(true);

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
