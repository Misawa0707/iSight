using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool[] itemFlags = new bool[ItemNum];

	// Use this for initialization
	void Start () {
        //  値の初期化
        for(int i = 0; i < ItemNum; i++)
        {
            itemFlags[i] = false;
        }
        //itemFlags[(int)Item.NightVisionFilter] = true;
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    //  指定したアイテムを持っているかどうか
    public bool GetItemFlag(Item item){
        return itemFlags[(int)item];
    }

    //  指定したアイテムのフラグを切り替える
    public void SetItemFlag(Item item, bool flag)
    {
        itemFlags[(int)item] = flag;
    }
}
