using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flag : MonoBehaviour {

    bool flagN = false;

    GameObject player;                     // プレイヤーオブジェクト
    NightVision NightVisionScript;         // 暗視のスクリプト

    [SerializeField]
    //  暗闇用
    public Image BlackImage;
    //  暗視用
    public Image GreenImage;

    private void Start()
    {
        player = GameObject.Find("Player");
        NightVisionScript = player.GetComponent<NightVision>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (NightVisionScript.FilterFlag == false)
            {
                GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.0f);
                BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            }

        }

    }

        void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            flagN = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (NightVisionScript.FilterFlag == false)
            {
                GreenImage.color = new Color(0.16f, 1.0f, 0.13f, 0.0f);
                BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            }
            flagN = false;
        }

    }

    //  フラグの取得
    public bool GetFlag()
    {
        return flagN;
    }
}

