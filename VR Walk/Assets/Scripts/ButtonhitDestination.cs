using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonhitDestination : MonoBehaviour {
    public Button AnswerButton;
    public GameObject Destination;
    public GameObject DesPort;
    public GameObject Teleport;
    public Text TimeCount;
    public float TimeLeft = 15f;
    private float TimeStart;
    private float TimeTeleport = 3.5f;
    private bool isTeleported;
    private string textCheck;

    void Start () {
        isTeleported = false;
        DesPort.GetComponent<Canvas>().enabled = false;
        //DesPort.SetActive(false);
    }
	
    public void CheckIPdes()
    {
        textCheck = AnswerButton.GetComponentInChildren<Text>().text;
        if (textCheck == "Ace Kingdom" || textCheck == "Froze Kingdom")
        {
            Destination.SetActive(false);
            DesPort.GetComponent<Canvas>().enabled = true;
            DesPort.SetActive(false);
            DesPort.SetActive(true);
        }
        else
        {
            Teleport.SetActive(true);
            isTeleported = true;
        }
    }

	void Update () {
        TimeStart += Time.deltaTime;
        if (TimeStart >= 2.5)
        {
            AnswerButton.gameObject.SetActive(true);
            TimeLeft -= Time.deltaTime;
            TimeCount.text = "Time: " + Mathf.Round(TimeLeft);
            //if(TimeLeft <= 12) AnswerButton.gameObject.SetActive(true);

            if (TimeLeft <= 3.5)
            {
                Teleport.SetActive(true);
                if (TimeLeft <= 0) SceneManager.LoadScene(0);
 
            }
        }

        if (isTeleported)
        {
            TimeTeleport -= Time.deltaTime;
            if (TimeTeleport <= 0) SceneManager.LoadScene(0);
        }
    }
}
