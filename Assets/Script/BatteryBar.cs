using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour {

   
    Slider slider;
    GameObject player;                     //   プレイヤーオブジェクト
    PlayerController playerScript;         //   プレイヤーのスクリプト

    // Use this for initialization
    void Start () {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = playerScript.Battery;
	}
}
