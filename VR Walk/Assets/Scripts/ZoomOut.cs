using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour {
    private int ZoomValue = 20;
    private int normal = 20;
    private float smooth = 5;
    public Camera vrCamera;

    private bool isZoomed = true;

    public void ZoomeCamOut()
    {


        if (isZoomed)
        {
            vrCamera.GetComponent<Camera>().fieldOfView += Mathf.Lerp(vrCamera.GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }

    }
}
