using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextHowToPlay : MonoBehaviour {
    public GameObject PageNow;
    public GameObject PageNext;
	// Use this for initialization
	void Start () {
        PageNext.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextPage()
    {
        PageNow.SetActive(false);
        PageNext.SetActive(true);
    }
}
