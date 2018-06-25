using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class button : MonoBehaviour {
    public GameObject menu;
    public GameObject flashtext;
    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
        {
            menu.SetActive(true);
            flashtext.SetActive(false);
        }
	}
}
