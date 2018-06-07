using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nightroom : MonoBehaviour {
    public Image BlackImage;
    // Use this for initialization
    void Start () {
        BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 0.2f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("暗い");
            BlackImage.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
    }
  
}
