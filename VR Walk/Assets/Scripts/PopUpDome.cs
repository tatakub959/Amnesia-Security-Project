using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDome : MonoBehaviour {

    public GameObject Skydome;
    public GameObject Smoke;
    private bool isShown = false;
    private bool inDome = true;
   

    void Start()
    {
        Skydome.SetActive(isShown);
        Smoke.SetActive(isShown);
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Player" || other.gameObject.name == "Player" && inDome == true)
        {
            isShown = true;
            Skydome.SetActive(isShown);
            Smoke.SetActive(isShown);
            Debug.Log(inDome);

        }
        if (inDome == false)
        {
            isShown = false;
            Skydome.SetActive(isShown);
            Smoke.SetActive(isShown);
        }

    }
   
    private void OnTriggerExit(Collider other)
    {
        inDome = false;

    }
    private void Update()
    {

    }

}
