using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonhitPort : MonoBehaviour
{
    public Button AnswerButton;
    public GameObject IPport;
    public GameObject Destination;
    public GameObject Teleport;
    public Text TimeCount;
    private float TimeStart;
    private float TimeTeleport = 3.5f;
    private bool isTeleported;
    private string textCheck;
    // Use this for initialization
    void Start()
    {
        isTeleported = false;
        //Destination.GetComponent<Canvas>().enabled = false;
        Destination.SetActive(false);
    }

    public void CheckIPport()
    {
        textCheck = AnswerButton.GetComponentInChildren<Text>().text;
        if (textCheck == "Midnight Cystal" || textCheck == "TestCube")
        {
            IPport.SetActive(false);
            //Destination.GetComponent<Canvas>().enabled = true;
            Destination.SetActive(true);
        }
        else
        {
            Teleport.SetActive(true);
            isTeleported = true;
            //SceneManager.LoadScene(0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        TimeStart += Time.deltaTime;
        if (TimeStart >= 2.5)
        {
            AnswerButton.gameObject.SetActive(true);
            /*
            TimeLeft -= Time.deltaTime;
            TimeCount.text = "Time: " + Mathf.Round(TimeLeft);
            //if(TimeLeft <= 12) AnswerButton.gameObject.SetActive(true);

            if (TimeLeft <= 3.5)
            {// Or load scene again;
                Teleport.SetActive(true);
                if (TimeLeft <= 0) SceneManager.LoadScene(0);
 
            }
        }

        if (isTeleported)
        {
            TimeTeleport -= Time.deltaTime;
            if (TimeTeleport <= 0) SceneManager.LoadScene(0);
        }*/
        }
    }
}
