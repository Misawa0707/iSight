using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemGet : MonoBehaviour {

 //   string ItemName;                //  取得したアイテム名
 //   ItemManager ItemScript;         //  アイテムマネージャーのスクリプト
 //   bool ItemFlag;                  //  アイテムを取得したかどうか

 //   [SerializeField]
 //   Image NightVisionImage;        //  暗視フィルターアイテムアイコン
 //   [SerializeField]
 //   Image KeyImage;                //  鍵アイテムアイコン

 //   List<Image> IconList;

 //   // Use this for initialization
 //   void Start () {
 //       //  値の初期化
 //       ItemFlag = false;
 //       ItemScript = GetComponent<ItemManager>();
 //       //ImageDisplay(NightVisionImage);
 //       //ImageDisplay(KeyImage);
 //   }
	
	//// Update is called once per frame
	//void Update () {

	//}

 //   private void OnControllerColliderHit(ControllerColliderHit hit)
 //   {
 //       //  アイテムの名前の取得
 //       ItemName = hit.gameObject.tag;
 //       //  アイテムの取得処理
 //       Get();

 //       //  アイテムを取得したならそのアイテムを消す
 //       if(ItemFlag)
 //       {
 //           Destroy(hit.gameObject);
 //           ItemFlag = false;
 //           ItemDisplay();
 //       }
 //   }

 //   //  取得する関数
 //   void Get()
 //   {
 //       //  アイテムを取得
 //       switch (ItemName)
 //       {
 //           //  暗視フィルター
 //           case "NightVisionFilter":
 //               ItemScript.SetItemFlag(ItemManager.Item.NightVisionFilter, true);
 //               //IconList.Add(NightVisionImage);
 //               ItemFlag = true;

 //               break;

 //           //  鍵
 //           case "Key":
 //               ItemScript.SetItemFlag(ItemManager.Item.Key, true);
 //               //IconList.Add(KeyImage);
 //               ItemFlag = true;
 //               break;

 //           //  バッテリー
 //           case "Battery":
 //               ItemScript.SetItemFlag(ItemManager.Item.Battery, true);
                
 //               ItemFlag = true;
 //               break;

 //           default:
 //               break;
 //       }
 //   }

 //   //  アイテムリストの表示
 //   void ItemDisplay()
 //   {
 //       //for(int i = 0; i < IconList.Count; i++)
 //       //{
 //       //    IconList[i].transform.position = new Vector3((-125 + i * 50), -215.0f, 0);
 //       //    ImageDisplay(IconList[i]);
 //       //}
 //   }

 //   //  画像の表示・非表示
 //   void ImageDisplay(Image image)
 //   {
 //       Color color = image.color;
 //       if (color.a > 0.0f)
 //       {
 //           color.a = 0.0f;
 //       }
 //       else
 //       {
 //           color.a = 1.0f;
 //       }

 //       image.color = color;
 //   }
}
