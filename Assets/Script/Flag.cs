using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour {

    bool flagN = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (flagN == false)
            {
                flagN = true;
            }
            else
            {
                flagN = false;
            }
        }
    }
}

