﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]
public class TestPlayVideo : MonoBehaviour {
    public MovieTexture movie;
    private AudioSource audio;
	// Use this for initialization
	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        movie.loop = true;
        audio.Play();
        
	}
	
	// Update is called once per frame
	void Update () {
        /*
		if(Input.GetKeyDown(KeyCode.Space) && movie.isPlaying)
        {
            movie.Pause();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !movie.isPlaying)
        {
            movie.Play();
        }
        */
    }
}
