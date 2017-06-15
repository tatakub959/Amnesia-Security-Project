using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestLookGazeTime : MonoBehaviour, TimeInput {
    Button Button;
	// Use this for initialization
	void Start () {
        //GetComponent<Renderer>().material.color = Color.blue;
        Button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HandleTimeInput()
    {
        Button.onClick.Invoke();

    }
}
