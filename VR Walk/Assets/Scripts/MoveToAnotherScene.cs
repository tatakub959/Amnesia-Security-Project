using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToAnotherScene : MonoBehaviour {

    public string Scene_Name;
	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(Scene_Name);

        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
