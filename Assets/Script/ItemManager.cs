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

//  アイテムデータクラス
public class ItemData
{
    public ItemManager.Item type;
}

public class ItemManager : MonoBehaviour
{

    //  アイテム数
    const int ItemNum = 3;

    //  アイテムの種類
    public enum Item
    {
        NightVisionFilter,          //  暗視フィルター
        Key,                        //  鍵
        Battery,                    //  バッテリー
        HintFilter                  //  ヒントフィルター
    };

    //  アイテムを持っているかどうかのフラグ
    [SerializeField]
    private bool[] itemFlags = new bool[ItemNum];
    private List<Item> itemList = new List<Item>();
    private List<GameObject> IconList = new List<GameObject>();

    string ItemName;            //  取得したアイテム名
    bool ItemFlag;              //  アイテムを取得したかどうか

    bool HintFlag;
    int ElapsedTime = 0;

    //  アイテムアイコン
    [SerializeField]
    GameObject NightVisionIcon;
    [SerializeField]
    GameObject KeyIcon;
    [SerializeField]
    GameObject BatteryIcon;
    [SerializeField]
    GameObject CanvasObject;

    [SerializeField] GameObject SubCamera;
    [SerializeField] Material GlowMat;

    GameObject player;                     // プレイヤーオブジェクト
    PlayerController playerScript;         // プレイヤーのスクリプト

    // Use this for initialization
    void Start()
    {
        //  値の初期化
        for (int i = 0; i < ItemNum; i++)
        {
            itemFlags[i] = false;
        }

        ItemFlag = false;
        HintFlag = false;

        //  プレイヤーのスクリプトの取得
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();

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
        // Rキーが押されたら
        if (Input.GetKeyDown(KeyCode.R))
        {
            //  バッテリーアイテムを使用したときの処理
            UseBattery();
        }

        //  Qキーが押されたら
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //  ヒントを使用したときの処理
            UseHint();
            HintFlag = true;
        }
        //  Hintを使ったら
        if(HintFlag)
        {
            ElapsedTime++;
        }

        //  時間経過でヒントを消す
        if(ElapsedTime > 180)
        {
            //  ヒント終了時の処理
            HintEnd();
            HintFlag = false;
            ElapsedTime = 0;
        }
    }

    //  指定したアイテムを持っているかどうか
    public bool GetItemFlag(Item item)
    {
        return itemFlags[(int)item];
    }

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

            //  ヒントフィルター
            case "HintFilter":
                itemList.Add(Item.HintFilter);
                ItemFlag = true;
                break;

            default:
                break;
        }
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
                        itemFlags[(int)Item.NightVisionFilter] = true;
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
                        itemFlags[(int)Item.Key] = true;
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


                case Item.Battery:
                    //  アイコンの生成
                    GameObject BIcon = Instantiate(BatteryIcon);
                    //  リスト内に同じアイテムが含まれるかどうかの検出
                    bool exitBIcon = IconList.Any(c => c.name == BIcon.name);

                    //  含まれていなければ加える
                    if (!exitBIcon)
                    {
                        itemFlags[(int)Item.Battery] = true;
                        BIcon.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
                        BIcon.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                        BIcon.transform.position = new Vector3((275.0f + i * 50), 24.0f, 0);
                        BIcon.transform.SetParent(CanvasObject.transform, false);
                        IconList.Add(BIcon);
                    }
                    else
                    {
                        //  存在していれば破棄
                        Destroy(BIcon);
                    }
                    break;

                default:
                    break;
            }

        }
    }

    void UseBattery()
    {
        if(GetItemFlag(Item.Battery))
        {
            playerScript.Battery = 1.0f;
            //RemoveItem();

        }
    }

    void UseHint()
    {

        SubCamera.SetActive(true);

        GameObject[] wall = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wi in wall)
        {
            wi.layer = LayerMask.NameToLayer("Hint");
            GlowMat.EnableKeyword("_EMISSION");
            GlowMat.SetColor("_EmissionColor", Color.red);
        }
        //Input.a
    }

    void HintEnd()
    {
        SubCamera.SetActive(false);

        GameObject[] wall = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wi in wall)
        {

            wi.layer = LayerMask.NameToLayer("Default");
            GlowMat.SetColor("_EmissionColor", Color.white);
            GlowMat.DisableKeyword("_EMISSION");
        }
    }

    //  アイテムの削除
    void RemoveItem()
    {
        itemFlags[(int)Item.Battery] = false;

        //  アイコンリストから削除

        //  アイテムリストから削除
    }
}

