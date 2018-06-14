using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //  変数の宣言
    public float Battery;           //  バッテリー
    GameObject player;              //  プレイヤーオブジェクト
    ChangeCamera changeCamera;      //  カメラ切り替えスクリプト
    public bool Flg = true;
    // Use this for initialization
    void Start()
    {
        //  変数の初期化処理
        Battery = 1.0f;
        player = GameObject.Find("Player");
        changeCamera = player.GetComponent<ChangeCamera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Flg == true)
        {
            //  カメラ使用時にバッテリーを減らす
            if (changeCamera.GetCameraFlag())
            {
                //  バッテリーが0以上なら
                if (Battery > 0)
                {
                    Battery -= 0.0001f;
                }
            }
        }

        //  FPSの表示(デバッグ用)
        //float fps = 1.0f / Time.deltaTime;
        //Debug.LogFormat("{0}fps", fps);
    }
}


    