using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideButton : MonoBehaviour {
    public Button[] WillHideButtons;
    public float TimeToHide = 2.5f;
	// Use this for initialization
	void Start () {
        for(int i = 0; i < WillHideButtons.Length; i++)
        {
            WillHideButtons[i].gameObject.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
        TimeToHide -= Time.deltaTime;
        if(TimeToHide <= 0)
        {
            for (int i = 0; i < WillHideButtons.Length; i++)
            {
                WillHideButtons[i].gameObject.SetActive(true);
            }
        }

    }
}
