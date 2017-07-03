using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour {
    public Text textCanvas;
    public float TimeFirstText = 3f;
    public float TimeSecText = 3f;
    private bool Nod;
    private bool shake;
    private int Count_Yes = 0;
    private int Count_No = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        TimeFirstText -= Time.deltaTime;
        if (TimeFirstText <= 0) textCanvas.text = "Are you from kingdom A?";

        if (Nod == true && shake == false && Count_Yes >= 0)
        {
            textCanvas.text = "Great! ";
            
            TimeSecText -= Time.deltaTime;
            
            if (TimeSecText <= 0 && Count_Yes >= 1)
                textCanvas.text = "So, you live in ABC village where has lots of Midnight Cystal right ?";

                if (Count_Yes >= 2)
                    textCanvas.text = "Wow!, I would like to visit there. Good Luck!";

                    if (Count_Yes >= 3)
                         textCanvas.text = "Good Luck!";

        }

        else if (Nod == false && shake == true && Count_No >= 0 )
        {
            textCanvas.color = Color.red;
            textCanvas.text = "GET LOST! ";
            //gameObject.GetComponent<Canvas>().enabled = false;
        }
    }


    public void Nodding()
    {
        Nod = true;
        shake = false;
        Debug.Log("NODDDDDDDDDDDDDDDDD: " + Count_Yes);
        Count_Yes++;
    }

    public void Shaking()
    {
        shake = true;
        Nod = false;
        Debug.Log("SHAKEEEEEEEEEEEEE: " + Count_No);
        Count_No++;
    }

}
