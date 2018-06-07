using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Romm : MonoBehaviour {
    public Image BlackImage;
    // Use this for initialization
    void Start() {
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("aaaaa");

            BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.2f);
        }
    }
}
