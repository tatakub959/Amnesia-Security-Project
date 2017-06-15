using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// Add to Button obj that want to be seleted by GvrRetice
public class Look : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image progressImage; 
    public bool isEntered = false;
    Button _button;
    float timeElapsed;

    void Awake()
    {
        _button = GetComponent<Button>();

    }

    public float GazeActivationTime = 2.0f;

    void Update()
    {
        if (isEntered)
        {
            timeElapsed += Time.deltaTime;
            progressImage.fillAmount = Mathf.Clamp(timeElapsed / GazeActivationTime, 0, 1);
            if (timeElapsed >= GazeActivationTime)
            {
                timeElapsed = 0;
                _button.onClick.Invoke();
                progressImage.fillAmount = 0;
                isEntered = false;
            }
        }
        else
        {
            timeElapsed = 0;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEntered = true;
        //Debug.Log("Pointer INNNNNNNNNNNNNNNNN");
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        isEntered = false;
        //Debug.Log("Pointer OUT");
        progressImage.fillAmount = 0;
    }

}
