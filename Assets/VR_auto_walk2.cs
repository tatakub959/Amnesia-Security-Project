using UnityEngine;
using System.Collections;

public class VR_auto_walk2 : MonoBehaviour {
    GvrHead head = null;
    private const int Right_Angle = 90;
    private bool isMoving = false;

    public float speed = 3.0F;
    public bool WalkWhenHit;
    public bool WalkWhenLookDown;

	// Use this for initialization
	void Start () {
        head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	// Update is called once per frame
	void Update () {
        if (WalkWhenHit && !WalkWhenLookDown && isMoving && GvrViewer.Instance.Triggered)
            isMoving = true;

        else if (WalkWhenHit && !WalkWhenLookDown && !isMoving && GvrViewer.Instance.Triggered)
            isMoving = false;

        if (isMoving)
        {
            Vector3 direction = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * speed * Time.deltaTime;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
            transform.Translate(rotation * direction);
        }
	}
}
