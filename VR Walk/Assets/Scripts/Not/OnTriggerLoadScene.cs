using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class OnTriggerLoadScene : MonoBehaviour {
   
    public string loadLevel = "Horror";

	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetButtonDown("Fire1"))
        {
            //Application.LoadLevel(loadLevel);
            SceneManager.LoadScene(loadLevel);
        }
    }
    void Update () {

    }
}
