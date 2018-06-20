using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FlashText : MonoBehaviour {

    private Text text;

    public float interval = 1.0f;   // 点滅周期

    // 点滅コルーチンを開始する
    void Start()
    {
        StartCoroutine("flash");
    }

    // 点滅コルーチン
    IEnumerator flash()
    {
        while (true)
        {
            GetComponent<Text>().enabled = !this.GetComponent<Text>().enabled;
            yield return new WaitForSeconds(interval);
        }
    }
}
