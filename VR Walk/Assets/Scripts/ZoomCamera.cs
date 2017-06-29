using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour {
    public int ZoomValue = 20;
    private int normal = 60;
    private float smooth = 5;
    public Camera vrCamera;

    private bool isZoomed = true;	
    /*
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            isZoomed = !isZoomed;
        }

        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, ZoomValue, Time.deltaTime * smooth);
        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
	}
    */
    public void ZoomeCam()
    {
 

        if (isZoomed)
        {
            vrCamera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(vrCamera.GetComponent<Camera>().fieldOfView, ZoomValue, Time.deltaTime * smooth);
        }

    }
}
