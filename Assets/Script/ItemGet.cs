using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemGet : MonoBehaviour {

    //  定数宣言
    const float OPACITY = 1.0f;     //  不透明
    const float SKELETON = 0.0f;    //  透明

    string ItemName;                //  取得したアイテム名
    ItemManager ItemScript;         //  アイテムマネージャーのスクリプト
    bool ItemFlag;                  //  アイテムを取得したかどうか
    [SerializeField]
    Image NightVisionImage;                 //  鍵アイテムアイコン

	// Use this for initialization
	void Start () {
        //  値の初期化
        ItemFlag = false;
        ItemScript = GetComponent<ItemManager>();
        NightVisionImage.color = new Color(227.0f / 255.0f, 255.0f / 255.0f, 54.0f / 255.0f, SKELETON);
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //  アイテムの名前の取得
        ItemName = hit.gameObject.tag;
        //  アイテムの取得処理
        Get();

        //  アイテムを取得したならそのアイテムを消す
        if(ItemFlag)
        {
            Destroy(hit.gameObject);
            ItemFlag = false;
        }
    }

        //  取得する関数
        void Get()
    {
        //  アイテムを取得
        switch (ItemName)
        {
            //  暗視フィルター
            case "NightVisionFilter":
                ItemScript.SetItemFlag(ItemManager.Item.NightVisionFilter, true);
                ItemFlag = true;
                NightVisionImage.color = new Color(227.0f / 255.0f, 255.0f / 255.0f, 54.0f / 255.0f, OPACITY);
                break;
            //  鍵
            case "Key":
                ItemScript.SetItemFlag(ItemManager.Item.Key, true);
                ItemFlag = true;
                
                break;
            //  バッテリー
            case "Battery":
                ItemScript.SetItemFlag(ItemManager.Item.Battery, true);
                ItemFlag = true;
                break;

            default:
                break;
        }
    }
}
