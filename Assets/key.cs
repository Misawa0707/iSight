using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{

    public GameObject Wall;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "keyBox")
        {
            Debug.Log("ひらく");
            Wall.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "keyBox")
        {
            Debug.Log("とじる");
            Wall.SetActive(false);
        }
    }
}
