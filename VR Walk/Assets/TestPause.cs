﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("p"))
        {
            Time.timeScale = 0;
        }
    }
}
