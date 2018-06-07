using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    //フェードインの秒数
    [SerializeField]
    private float fadeTime;

    //背景
    private Image image;

	// Use this for initialization
	void Start () {
        image = transform.Find("Panel").GetComponent<Image>();
        //コルーチンで待ち時間の計算
        fadeTime = 1f * fadeTime / 10f;
        StartCoroutine("FadeIn");
        
	}

    IEnumerator FadeIn()
    {
        //アルファ値を0.1ずつ下げていく
        for(var i = 1f;i>=0;i-=0.1f)
        {
            image.color = new Color(0f, 0f, 0f, i);
            //　秒数待つ
            yield return new WaitForSeconds(fadeTime);
        }
       
    }
}
