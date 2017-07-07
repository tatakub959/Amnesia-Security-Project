using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    //private Animator myAim;
    public GameObject sword;
    public GameObject Max;
    public float TimeCountToDie = 3f;

    private bool isAttacked = false;
    private bool MaxisDead;
    // Use this for initialization
    void Start()
    {
        MaxisDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacked == true)
        {
            TimeCountToDie -= Time.deltaTime;
            /*
            if(TimeCountToDie <= 0)
            {
                
                Max.GetComponent<Animation>().Play("death");
                MaxisDead = true;
                sword.GetComponent<Animation>().Stop();
            }
            */
        }

    }
    /*
    private void Attack()
    {
        myAim.SetTrigger("Attack");
    }
    */

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (MaxisDead == false)
            {
                sword.GetComponent<Animation>().Play();
                isAttacked = true;
                if (TimeCountToDie <= 0)
                {
                    Max.GetComponent<Animation>().Play("death");
                    MaxisDead = true;
                    sword.GetComponent<Animation>().Stop();
                    isAttacked = false;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sword.GetComponent<Animation>().Stop();
            isAttacked = false;
        }
    }
}
