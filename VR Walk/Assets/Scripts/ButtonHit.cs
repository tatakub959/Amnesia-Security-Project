using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Just action when hit button, add to the main canvas and then drag canvas to the onclick flied of that button
public class ButtonHit : MonoBehaviour {
    public Button AnswerButton;

    public GameObject Player;
    public GameObject IPsource;
    public GameObject IPport;
    public GameObject Teleport;
    public Text TimeCount;
    public float TimeLeft=15f;
    private float TimeStart;
    private float TimeTeleport = 3.5f;
    private bool isTeleported;
    private string textCheck;

    public Vector3 Positon = new Vector3(-41f, 62.75f, -131f);
    public Vector3 Rotation = new Vector3(0f, 102f, 0f);

    private void Start()
    {
        isTeleported = false;
        IPport.GetComponent<Canvas>().enabled = false;
        //IPport.SetActive(false);
        
        
    }

    public void CheckIPsource()
    {
        textCheck = AnswerButton.GetComponentInChildren<Text>().text;
        if (textCheck == "Kingdom A" || textCheck == "Kingdom B")
        {

            IPsource.SetActive(false);
           
            IPport.GetComponent<Canvas>().enabled = true;
            IPport.SetActive(false);
            IPport.SetActive(true);
        }
        else
        {
            Teleport.SetActive(true);
            isTeleported = true;
            //SceneManager.LoadScene(0);
        }
        
    }

    private void Update()
    {
        TimeStart += Time.deltaTime;
        if (TimeStart >= 2.5)
        {
            AnswerButton.gameObject.SetActive(true);
            TimeLeft -= Time.deltaTime;
            TimeCount.text = "Time: " + Mathf.Round(TimeLeft);
            //if(TimeLeft <= 12) AnswerButton.gameObject.SetActive(true);

            if (TimeLeft <= 3.5)
            {// Or load scene again;
                Teleport.SetActive(true);
                if(TimeLeft <= 0) SceneManager.LoadScene(0);
                /*
                Player.transform.position = Positon;
                Player.transform.localEulerAngles = Rotation;
                Teleport.SetActive(false);
                */
            }
        }

        if (isTeleported)
        {
            TimeTeleport -= Time.deltaTime;
            if(TimeTeleport <= 0) SceneManager.LoadScene(0);
        }
    }

}
