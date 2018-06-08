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


public class ItemManager : MonoBehaviour
{

    //  アイテム数
    const int ItemNum = 3;

    //  アイテムの種類
    public enum Item
    {
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

    [SerializeField]
    GameObject NightVisionIcon;
    [SerializeField]
    GameObject KeyIcon;
    [SerializeField]
    GameObject CanvasObject;

    // Use this for initialization
    void Start()
    {
        //  値の初期化
        //for(int i = 0; i < ItemNum; i++)
        //{
        //    itemFlags[i] = false;
        //}
        //itemFlags[(int)Item.NightVisionFilter] = true;

        ItemFlag = false;


        //var key1 = Instantiate( keyPrefab );
        //var key2 = Instantiate(keyPrefab);
        //IconList.Add(key1);
        //var exist = IconList.Contains(key2); // false

        //var exist = IconList.Contains(obj); // 指定したオブジェクトが存在すれば true　完全一致
        //var exist = IconList.Any(c => c.name == obj.name); // 指定した条件を満たす要素が1つでもあれば true 部分一致
        ////var exist = IconList.All(c => c.name == obj.name); // すべての要素が条件を満たしている場合 true

        //if ( !exist)
        //{
        //    IconList.Add(obj);
        //}

    }

    // Update is called once per frame
    void Update()
    {

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
        

        for (int i = 0; i < itemList.Count; i++)
        {
            switch (itemList[i])
            {
               

                case Item.NightVisionFilter:
                    //  アイコンの生成
                    GameObject NVIcon = Instantiate(NightVisionIcon);
                    //  リスト内に同じアイテムが含まれるかどうかの検出
                    bool exitNVIcon = IconList.Any(c => c.name == NVIcon.name);

                    //  含まれていなければ加える
                    if (!exitNVIcon)
                    {
                        NVIcon.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                        NVIcon.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                        NVIcon.transform.position = new Vector3((275.0f + i * 50), 24.0f, 0);
                        NVIcon.transform.SetParent(CanvasObject.transform, false);
                        IconList.Add(NVIcon);
                    }
                    else
                    {
                        //  存在していれば破棄
                        Destroy(NVIcon);
                    }
                    
                    break;

                case Item.Key:
                    //  アイコンの生成
                    GameObject KIcon = Instantiate(KeyIcon);
                    //  リスト内に同じアイテムが含まれるかどうかの検出
                    bool exitKeyIcon = IconList.Any(c => c.name == KIcon.name);

                    //  含まれていなければ加える
                    if (!exitKeyIcon)
                    {
                        KIcon.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                        KIcon.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                        KIcon.transform.position = new Vector3((275.0f + i * 50), 24.0f, 0);
                        KIcon.transform.SetParent(CanvasObject.transform, false);
                        IconList.Add(KIcon);
                    }
                    else
                    {
                        //  存在していれば破棄
                        Destroy(KIcon);
                    }
                    break;

                default:
                    break;
            }

        }
    }
}

