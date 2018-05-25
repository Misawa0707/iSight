﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFilter : MonoBehaviour {

    [SerializeField]
    Material mat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Graphics.Blit(src, dest, mat);
    }
}
