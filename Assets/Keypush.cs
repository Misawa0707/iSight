using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Keypush : MonoBehaviour {
    public GameObject endB;
    public GameObject titB;
    public GameObject keytext;
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            endB.SetActive(true);
            titB.SetActive(true);
            keytext.SetActive(false);
            FirstPersonController fpc = GetComponent<FirstPersonController>();
            fpc.enabled = false;
            // 標準モード
            Cursor.lockState = CursorLockMode.None;
            // カーソル表示
            Cursor.visible = true;
        }
    }
}
