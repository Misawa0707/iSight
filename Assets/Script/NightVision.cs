using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  暗視フィルター
public class NightVision : MonoBehaviour {

    [SerializeField]
    //  暗闇用
    public Image BlackImage;
    //  暗視用
    public Image GreenImage;

    private bool FilterFlag;

    //  アイテム
    //ItemManager item;

    // Use this for initialization
    void Start () {
        //  値の初期化
        GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.5f);
        BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.2f);
        FilterFlag = false;
        //item = GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //アイテムを所持しているかどうか
        //if (item.GetItemFlag(ItemManager.Item.NightVisionFilter))
        {
            //  スペースキーが押されたら
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            ////  暗視用の部屋にいるかどうか
            //if ()
            //{
            //    //  暗視の部屋なら
            //    NightVisionRoom();
            //}
            //else
            //{
            //    //  通常時なら
            //    NormalRoom();
            //}

        }
    }

    //  暗視用の部屋処理
    void NightVisionRoom()
    {
        if (!FilterFlag)
        {

            GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.0f);
            BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            FilterFlag = true;
        }
        else
        {
            GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.5f);
            BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.2f);
            FilterFlag = false;
        }
    }

    //  通常時の暗視フィルター処理
    void NormalRoom()
    {
        if (!FilterFlag)
        {

            GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.0f);
            BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            FilterFlag = true;
        }
        else
        {
            GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.5f);
            BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.2f);
            FilterFlag = false;
        }
    }
}
