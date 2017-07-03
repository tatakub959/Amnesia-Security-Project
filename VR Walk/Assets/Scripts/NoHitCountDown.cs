using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NoHitCountDown : MonoBehaviour {
    //public Button hitButton;
    public GameObject Canvas;
    public Text TimeCount;
    public GameObject Teleport;
    public float TimeLeft = 15f;
    private float TimeStart;
    private bool isTeleported;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // if (hitButton.gameObject.GetComponent<ButtonhitPort>().buttonExist == false)
       if(Canvas.GetComponent<Canvas>().enabled == true)
        {

            TimeStart += Time.deltaTime;
            if (TimeStart >= 2.5)
            {
                TimeLeft -= Time.deltaTime;
                TimeCount.text = "Time: " + Mathf.Round(TimeLeft);
                if (TimeLeft <= 3.5)
                {
                    Teleport.SetActive(true);
                    if (TimeLeft <= 0) SceneManager.LoadScene(0);

                }
            }
        }
    }
}
