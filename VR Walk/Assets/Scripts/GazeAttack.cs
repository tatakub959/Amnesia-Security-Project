using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GazeAttack : MonoBehaviour
{

    public Image progressImage;
    public bool isEntered;
    float timeElapsed;
    public GameObject sword;
    public GameObject Max;
    public GameObject AttackUI;
    public GameObject AI;
    public GameObject Dialouge;
    public GameObject Hurts;
    public GameObject ItemDrop;
    public float TimeCountToDie = 3f;
    private bool isAttacked = false;
    private bool MaxisDead;
    // Use this for initialization
    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
        if (isEntered && MaxisDead == false )
        {

            timeElapsed += Time.deltaTime;
            float calculate = Mathf.Clamp(timeElapsed / TimeCountToDie, 0, 1);
            progressImage.fillAmount = calculate;
            sword.GetComponent<Animation>().Play();
            Dialouge.SetActive(false);
            Hurts.SetActive(true);
            if (timeElapsed >= TimeCountToDie)
            {
                timeElapsed = 0;
                Max.GetComponent<Animation>().Play("death");
                sword.GetComponent<Animation>().Stop();
                progressImage.fillAmount = 0;
                MaxisDead = true;
                Max.GetComponent<CapsuleCollider>().enabled = false;
                AttackUI.SetActive(false);
                AI.SetActive(false);
                ItemDrop.SetActive(true);
                Hurts.SetActive(false);
                //Destroy(sword);
            }
        }
    }

    public void OnPointerEnter()
    {
        isEntered = true;
        Debug.Log("Pointer INNNNNNNNNNNNNNNNN");
    }



    public void OnPointerExit()
    {
        isEntered = false;
        Debug.Log("Pointer OUT");
        progressImage.fillAmount = 0;
        sword.GetComponent<Animation>().Stop();
    }

}
