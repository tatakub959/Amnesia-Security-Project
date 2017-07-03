using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonhitDesPort : MonoBehaviour {
    public Button AnswerButton;
    public GameObject DesPort;
    public GameObject Teleport;
    public GameObject AllButtons;
    public GameObject Waypoint;
    public Text label;
    private float TimeStart=0;
    private bool isTeleported;
    private string textCheck;
    private bool end;


    void Start () {
        isTeleported = false;
    }
	
	public void CheckDesPort()
    {
        textCheck = AnswerButton.GetComponentInChildren<Text>().text;
        if (textCheck == "Test Sphere" || textCheck == "TestCylinder")
        {
            //AllButtons.SetActive(false);
            DesPort.GetComponent<NoHitCountDown>().enabled = false;
            label.text = "Good Luck!";
            end = true;
            
        }
        else
        {
            Teleport.SetActive(true);
            isTeleported = true;
        }
    }

    void Update()
    {
        if (end == true)
        {
            TimeStart += Time.deltaTime;
            if (TimeStart >= 3.5)
            {
                Waypoint.SetActive(true);
                DesPort.SetActive(false);
                AllButtons.SetActive(false);
            }
        }
    }
}
