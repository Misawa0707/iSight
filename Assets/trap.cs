using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour {

    public GameObject Wall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Wall.SetActive(false);
        }
    }
}
