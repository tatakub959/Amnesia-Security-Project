using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractiveObj))]
public class PickUpObj : MonoBehaviour {

    public Vector3 handPosition;
    public Vector3 handRotation;

    private Transform vrCam;
    private Transform handMountingPosition;
	// Use this for initialization
	void Start () {
        vrCam = Camera.main.transform;
        handMountingPosition = vrCam.GetChild(0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveToPlayerHand()
    {
        transform.parent = handMountingPosition;
        transform.localPosition = Vector3.zero;
        transform.localPosition += handPosition;
        transform.localEulerAngles = handRotation;
    }
}
