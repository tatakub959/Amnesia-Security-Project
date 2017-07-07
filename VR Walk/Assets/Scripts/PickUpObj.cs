using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractiveObj))]
public class PickUpObj : MonoBehaviour {
    public GameObject attackUI;
    public Vector3 handPosition;
    public Vector3 handRotation;

    private Transform vrCam;
    private Transform handMountingPosition;
	// Use this for initialization
	void Start () {
        vrCam = Camera.main.transform;
        handMountingPosition = vrCam.GetChild(0);
        attackUI.SetActive(false);
        //Debug.Log("handPosition: " + handPosition);S
        //Debug.Log("handRotation: " + handRotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveToPlayerHand()
    {
        //Debug.Log("handPosition: " + handPosition);
        //Debug.Log("handRotation: " + handRotation);
        transform.parent = handMountingPosition;
        transform.localPosition = Vector3.zero;
        /*
        transform.localPosition = new Vector3(0.1f, -0.5f, 0f);
        transform.localEulerAngles = new Vector3(-35f, 1.8f,83f);
        */
        
        transform.localPosition = handPosition;
        transform.localEulerAngles = handRotation;
        attackUI.SetActive(true);
        attackUI.GetComponentInChildren<Animation>().Play();
        //Debug.Log(vrCam.GetChild(0).GetChild(0));
    }
}
