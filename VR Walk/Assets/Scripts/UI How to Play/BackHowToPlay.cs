using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHowToPlay : MonoBehaviour {
    public GameObject PageNow;
    public GameObject PageBack;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackToPage()
    {
        PageNow.SetActive(false);
        PageBack.SetActive(true);
        
    }
}
