﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorpositioner : MonoBehaviour {
    private float defaultposZ;
	// Use this for initialization
	void Start () {
        defaultposZ = transform.localPosition.z;

    }
	
	// Update is called once per frame
	void Update () {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if(Physics.Raycast (ray,out hit))
        {
            if (hit.distance <= defaultposZ)
            {
                transform.localPosition = new Vector3(0, 0, hit.distance);
            }
            else
            {
                transform.localPosition = new Vector3(0, 0, defaultposZ);
            }
            
        }
        
	}
}
