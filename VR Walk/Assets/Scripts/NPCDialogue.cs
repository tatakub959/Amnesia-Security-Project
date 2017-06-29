using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour {
    public Text textCanvas;
    public float TimeText = 15f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeText -= Time.deltaTime;
        if (TimeText <= 12) textCanvas.text = "Do you from kingdom A?";
        if (TimeText <= 8) textCanvas.text = "Great! ";
        if (TimeText <= 5) textCanvas.text = "So, you live in ABC village where has lots of Moon flower right ?";



    }

}
