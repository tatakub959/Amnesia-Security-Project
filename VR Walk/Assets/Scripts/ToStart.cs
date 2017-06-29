using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToStart : MonoBehaviour {
    public Vector3 Positon = new Vector3(-22.38f, 32.918f, -10f);
    public Vector3 Rotation = new Vector3(10f, -11f, 0f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.name == "Player")
        {
            other.transform.position = Positon;
            transform.localEulerAngles = Rotation;
            Debug.Log("HiT by Trig");
            GetComponent<Collider>().enabled = false;
            GetComponent<Collider>().enabled = true;

        }
    }

}
