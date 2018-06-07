using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//---------------------------------------------------------------------------
//インベントリシステム

//public class ItemData
//{
//    public ItemManager.Item type;
//}

// private List<ItemData> itemFlags = new List<ItemData>();

// private List<Item> itemFlags = new List<Item>();　// ★おすすめ

// itemFlags.Add( new ItemData { type = Type.Battery } );
// itemFlags.Add( Type.Battery );
// itemFlags.Contains( Type.Battery )
// itemFlags.Remove
// itemFlags.RemoveAt( 2 )
// itemFlags.RemoveAll( c => c.type == Type.Battery ); // ラムダ式

//---------------------------------------------------------------------------


public class ItemManager : MonoBehaviour {

    //  アイテム数
    const int ItemNum = 3;

    //  アイテムの種類
    public enum Item{
        NightVisionFilter,          //  暗視フィルター
        Key,                        //  鍵
        Battery                     //  バッテリー
    };

    //  アイテムを持っているかどうかのフラグ
    [SerializeField]
    //private bool[] itemFlags = new bool[ItemNum];
    private List<Item> itemList = new List<Item>();
    private List<GameObject> IconList = new List<GameObject>();

    string ItemName;            //  取得したアイテム名
    bool ItemFlag;              //  アイテムを取得したかどうか

    [SerializeField] GameObject NightVisionIcon;
    [SerializeField] GameObject KeyIcon;
    [SerializeField] GameObject CanvasObject;

    // Use this for initialization
    void Start () {
        //  値の初期化
        //for(int i = 0; i < ItemNum; i++)
        //{
        //    itemFlags[i] = false;
        //}
        //itemFlags[(int)Item.NightVisionFilter] = true;

        ItemFlag = false;

    }
	
	// Update is called once per frame
	void Update () {
       
	}

    //  指定したアイテムを持っているかどうか
    //public bool GetItemFlag(Item item){
    //return itemFlags[(int)item];
    //}

    //  指定したアイテムのフラグを切り替える
    //public void SetItemFlag(Item item, bool flag)
    //{
    //    itemFlags[(int)item] = flag;
    //}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //  アイテムの名前の取得
        ItemName = hit.gameObject.tag;
        //  アイテムの取得処理
        Get();

        //  アイテムを取得したならそのアイテムを消す
        if (ItemFlag)
        {
            InventoryDisplay();
            Destroy(hit.gameObject);
            ItemFlag = false;
        }
    }

    //  アイテムの取得
    void Get()
    {
        //  アイテムを取得
        switch (ItemName)
        {
            //  暗視フィルター
            case "NightVisionFilter":
                itemList.Add(Item.NightVisionFilter);
                ItemFlag = true;

                break;

            //  鍵
            case "Key":
                itemList.Add(Item.Key);
                ItemFlag = true;
                break;

            //  バッテリー
            case "Battery":
                itemList.Add(Item.Battery);
                ItemFlag = true;
                break;

            default:
                break;
        }
    }

    //  アイテムを所持しているか
    public bool isHaveItem(Item item)
    {
        bool isHave;
        isHave = itemList.Contains(item);
        return isHave;
    }

    //  アイテム欄の表示
    void InventoryDisplay()
    {
        for(int i = 0; i < itemList.Count; i++)
        {
            switch (itemList[i])
            {
                case Item.NightVisionFilter:
                    GameObject NVIcon = Instantiate(NightVisionIcon);
                    NVIcon.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                    NVIcon.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                    NVIcon.transform.position = new Vector3((275.0f + i * 50), 24.0f, 0);
                    NVIcon.transform.SetParent(CanvasObject.transform, false);
                    IconList.Add(NVIcon);
                    IconList.Distinct();
                    break;

                case Item.Key:
                    GameObject KIcon = Instantiate(KeyIcon);
                    KIcon.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                    KIcon.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                    KIcon.transform.position = new Vector3((275.0f + i * 50), 24.0f, 0);
                    KIcon.transform.SetParent(CanvasObject.transform, false);
                    IconList.Add(KIcon);
                    IconList.Distinct();
                    break;

                default:
                    break;
            }

        }
    }
}
