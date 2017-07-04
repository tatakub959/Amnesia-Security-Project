using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class StartScene : MonoBehaviour {
    public GameObject HeadManager;
    Text Play;
    //public float TimeCount = 0;
    private bool isHit = false;
    public Image progressImage;
    private float timeElapsed= 0;
    public float TimetoStart = 3.0f;
    public GameObject quitButton;
    public Camera cam;


    // Use this for initialization
    void Start () {
        Play = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
		if(isHit == true)
        {
            /*
            TimeCount += Time.deltaTime;
            if (TimeCount >= 4)
            {
                SceneManager.LoadScene("Main Backup");
            }
            */
            timeElapsed += Time.deltaTime;
            float calculate = Mathf.Clamp(timeElapsed / TimetoStart, 0, 1);
            progressImage.fillAmount = calculate;
            cam.GetComponent<VignetteAndChromaticAberration>().intensity = calculate;
            if (timeElapsed >= TimetoStart)
            {
                timeElapsed = 0;
                SceneManager.LoadScene("Main Backup");
                progressImage.fillAmount = 0;
                isHit = false;
            }
 
        }
	}

    public void HitToStart()
    {
        isHit = true;
        HeadManager.SetActive(false);
        Play.color = new Color(178/255, 255/255 , 102/255);
        quitButton.SetActive(false);
       
    }
}
