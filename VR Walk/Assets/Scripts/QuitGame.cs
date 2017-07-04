using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour {
    public float quitTime = 3;
    private bool isQuited = false;
    Text quitText;
    public Image progressImage;
    private float timeElapsed = 0;
    public GameObject StartButton;

    public void QuitingGame()
    {
        
        isQuited = true;
        quitText = GetComponent<Text>();
        //quitText.color = Color.red;
        quitText.color = new Color(255/255 , 102/255, 102/255);
        StartButton.SetActive(false);
    }
    public void Update()
    {
        if(isQuited == true)
        {
            /*
            quitTime -= Time.deltaTime;
            if(quitTime <= 0)
            {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif

                //Application.Quit();
            }
            */
            timeElapsed += Time.deltaTime;
            progressImage.fillAmount = Mathf.Clamp(timeElapsed / quitTime, 0, 1);
            if (timeElapsed >= quitTime)
            {
                timeElapsed = 0;

                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif

                progressImage.fillAmount = 0;
                isQuited = false;
            }

        }
    }
}
