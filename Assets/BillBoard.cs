using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 Player = Camera.main.transform.position;
        Player.y = transform.position.y;
        transform.LookAt(Player);
    }
}
