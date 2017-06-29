using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour {

    public Text textCanvas;
    public float TimeText = 2.5f;
	// Use this for initialization
	void Start () {
        textCanvas.text = "Hello!";
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeText -= Time.deltaTime;
        if(TimeText <= 0)
        {
            textCanvas.text = "Where do you come from? (IP source)";
        }
	}
}
