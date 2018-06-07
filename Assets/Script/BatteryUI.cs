using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour {

    [SerializeField]
    public Text batteryText;

    GameObject player;                     //   プレイヤーオブジェくト
    PlayerController playerScript;         //   プレイヤーのスクリプト
    float BatteryPercent;

    // Use this for initialization
    void Start () {
        //  変数の初期化
        batteryText.text = "0";
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
            BatteryPercent = playerScript.Battery * 100.0f;
            batteryText.text = BatteryPercent.ToString("f0") + "%";
    }
}
