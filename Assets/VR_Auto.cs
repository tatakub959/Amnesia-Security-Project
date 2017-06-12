using UnityEngine;
using System.Collections;

public class VR_Auto : MonoBehaviour {
    public float speed = 3.0F;
    public bool moveForward = false;
    private bool moveByClick = false;
    private bool moveByLookDown = false;
    private CharacterController controller;
    private GvrViewer gvrViewer;
    private Transform vrHead;

    public float LookAngle = 20.0f;

	// Use this for initialization
	void Start () {

        controller = GetComponent<CharacterController>();
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
        vrHead = Camera.main.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            moveForward = !moveForward;
        }
        /*
        if (vrHead.eulerAngles.x >= LookAngle && vrHead.eulerAngles.x < 90.0)
        {
            moveForward = true;
        }
        */


        if (moveForward)
        {
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
	    
	}
}
