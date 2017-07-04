using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
    Text title;
    private float target_alpha = 1.0F;
    private float duration = 2.0F;

    // Use this for initialization
    void Start () {

       title = GetComponent<Text>();
       title.canvasRenderer.SetAlpha(0.0f);
    }
	
	// Update is called once per frame
	void Update () {
       title.CrossFadeAlpha(target_alpha, duration, false);
    }



}
