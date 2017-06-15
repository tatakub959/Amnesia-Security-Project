using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Pop the menu or dialogue when Player make a collision with the NPC or obj, add to the NPC or obj that you want to hit
public class PopUp : MonoBehaviour {
    public GameObject PopObj;
    private bool isShown = false;
	// Use this for initialization
	void Start () {
        PopObj.SetActive(isShown);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isShown = true;
            PopObj.SetActive(isShown);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isShown = false;
        PopObj.SetActive(isShown);
    }
    // Update is called once per frame
    void Update () {

        
	}
}
