using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInUI : MonoBehaviour
{
    public CanvasGroup title;
    private float target_alpha = 1.0F;
    private float duration = 2.0F;

    // Use this for initialization
    void Start()
    {

        title.GetComponent<CanvasGroup>().alpha = 0.0f;
        //title.CanvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        title.GetComponent<CanvasGroup>().alpha += Time.deltaTime / duration;
    }



}
