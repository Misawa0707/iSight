using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    [SerializeField]
    private GameObject NormalCamera;       // 通常時に使用するカメラ
    [SerializeField]
    private GameObject PlayerCamera;       // プレイヤーがカメラ使用時の別カメラ
                                              
    private bool useCameraFlag;            // カメラを使用しているかどうかのフラグ
                                              
    GameObject player;                     // プレイヤーオブジェクト
    PlayerController playerScript;         // プレイヤーのスクリプト

    //  アイテム
    ItemManager item;

    //壁の配列
    public GameObject[] wall;

    // Use this for initialization
    void Start () {
        // プレイヤーがカメラ使用時のカメラを非アクティブにする
        PlayerCamera.SetActive(false);

        //  変数の初期化処理
        useCameraFlag = false;
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();

        item = GetComponent<ItemManager>();
        //タグWallを探す
        wall = GameObject.FindGameObjectsWithTag("Wall");
    }

    // Update is called once per frame
    void Update () {

        // スペースキーが押されたら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // バッテリーがあれば
            if (playerScript.Battery < 0) return;

            // それぞれのカメラのアクティブ状態を反転する
            if (NormalCamera.activeSelf)
            {
                NormalCamera.SetActive(false);
                PlayerCamera.SetActive(true);
                foreach (GameObject wi in wall)
                {
                    //オブジェクトを非表示にする
                    wi.SetActive(false);
                }

                // カメラ使用のフラグをtrueにする
                useCameraFlag = true;
            }
            else
            {
                NormalCamera.SetActive(true);
                PlayerCamera.SetActive(false);
                foreach (GameObject wi in wall)
                {
                    //オブジェクトを表示する
                    wi.SetActive(true);
                }

                // カメラ使用のフラグをfalseにする
                useCameraFlag = false;
            }
        }

        // バッテリーがなくなったらカメラの使用を止める
        if(playerScript.Battery < 0)
        {
            //  バッテリーがなくなったとき
            BatteryNone();

            NormalCamera.SetActive(true);
            PlayerCamera.SetActive(false);
        }

        //アイテムを所持しているかどうか
        if (item.GetItemFlag(ItemManager.Item.NightVisionFilter))
        {
            if (!PlayerCamera.activeSelf) return;
                ChangeFilter();
        }

    }
    

    // カメラの使用状態の取得
    public bool GetCameraFlag()
    {
        return useCameraFlag;
    }

    //  フィルターの切り替え
    void ChangeFilter()
    {
        //  Xキーが押されたら
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (PlayerCamera.GetComponent<PostEffect>().enabled)
            {
                //  カメラエフェクトオフ
                PlayerCamera.GetComponent<PostEffect>().enabled = false;
                //  フィルターの値をリセット
                player.GetComponent<NightVision>().GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.5f);
                player.GetComponent<NightVision>().BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.2f);
                player.GetComponent<NightVision>().enabled = true;

                foreach (GameObject wi in wall)
                {
                    //オブジェクトを表示する
                    wi.SetActive(true);
                }
            }
            else
            {
                //  カメラエフェクトオン
                PlayerCamera.GetComponent<PostEffect>().enabled = true;

                //  フィルターの値をリセット
                player.GetComponent<NightVision>().GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.0f);
                player.GetComponent<NightVision>().BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                player.GetComponent<NightVision>().enabled = false;

                foreach (GameObject wi in wall)
                {
                    //オブジェクトを表示する
                    wi.SetActive(false);
                }
            }
        }
        
    }

    //  バッテリーがなくなったときの処理
    public void BatteryNone()
    {
        //  フィルターの値をリセット
        player.GetComponent<NightVision>().GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.0f);
        player.GetComponent<NightVision>().BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        player.GetComponent<NightVision>().enabled = false;

        foreach (GameObject wi in wall)
        {
            //オブジェクトを表示する
            wi.SetActive(true);
        }
    }
}
