using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrap : MonoBehaviour {

    public GameObject Wall;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MoveBox")
        {
            Debug.Log("ひらく");
            Wall.SetActive(false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MoveBox")
        {
            Debug.Log("とじる");
            Wall.SetActive(true);
        }
    }
}
