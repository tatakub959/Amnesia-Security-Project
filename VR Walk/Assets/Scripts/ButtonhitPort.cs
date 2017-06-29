using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonhitPort : MonoBehaviour {
    public Button AnswerButton;
    public Text TimeCount;
    public float TimeLeft = 15f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeLeft -= Time.deltaTime;
        TimeCount.text = "Time: " + Mathf.Round(TimeLeft);
        if (TimeLeft <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CheckPort()
    {

    }
}
