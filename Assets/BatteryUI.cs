using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour {

    [SerializeField]
    public Text batteryText;

    GameObject player;                     //   プレイヤーオブジェくト
    PlayerController playerScript;         //   プレイヤーのスクリプト

    // Use this for initialization
    void Start () {
        batteryText.text = "0";
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        batteryText.text = playerScript.Battery.ToString("f0");

    }
}
