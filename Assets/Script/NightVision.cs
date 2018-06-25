using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//  暗視フィルター
public class NightVision : MonoBehaviour
{

    [SerializeField]
    //  暗闇用
    public Image BlackImage;
    //  暗視用
    public Image GreenImage;
    //  カメラ
    [SerializeField] GameObject PlayerCamera;

    public bool FilterFlag;
    GameObject nightwall;
    private Flag Nflag;
    
    //  アイテム
    ItemManager item;

    // Use this for initialization
    void Start()
    {
        //  値の初期化
        GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.5f);
        BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.2f);
        FilterFlag = false;
        item = GetComponent<ItemManager>();

        nightwall = GameObject.Find("nightwall");
        Nflag = nightwall.GetComponent<Flag>();
    }

    // Update is called once per frame
    void Update()
    {

        //アイテムを所持しているかどうか
        if (item.GetItemFlag(ItemManager.Item.NightVisionFilter))
        {
            if (PlayerCamera.activeSelf == false) return;
            if (!Input.GetKeyDown(KeyCode.X)) return;

            //  暗視用の部屋にいるかどうか
            if (Nflag.GetFlag())
            {
                //  暗視の部屋なら
                NightVisionRoom();
            }
            else
            {
                //  通常時なら
                NormalRoom();
            }
        }
        else if (Nflag.GetFlag())
        {
            DarknessFilter();
            FilterFlag = false;
        }
        else
        {
            NormalVisionFilter();
            FilterFlag = false;
        }


    }

    //  暗視用の部屋処理
    void NightVisionRoom()
    {
        if (FilterFlag == false)
        {
            NightVisionFilter();
            FilterFlag = true;
        }
        else
        {
            DarknessFilter();
            FilterFlag = false;
        }
    }

    //  通常時の暗視フィルター処理
    void NormalRoom()
    {
        if (FilterFlag == false)
        {
            NightVisionFilter();
            FilterFlag = true;
        }
        else
        {
            NormalVisionFilter();
            FilterFlag = false;
        }
    }

    //  通常時
    void NormalVisionFilter()
    {
        GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.0f);
        BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }
    //  暗視時
    void NightVisionFilter()
    {
         GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.5f);
         BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.2f);
    }

    //  暗闇時
    void DarknessFilter()
    {
        GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.0f);
        BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }
}
