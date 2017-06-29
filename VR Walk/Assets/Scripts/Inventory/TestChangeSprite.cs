using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestChangeSprite : MonoBehaviour {
    public Image TestSprite;

    // Update is called once per frame
    private void Start()
    {
        //TestSprite = Resources.Load<Sprite>("Red_Dot");

    }
    void Update () {
        TestSprite.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Red_Dot");
        //TestSprite.transform.GetChild(2).GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Red_Dot");
        //TestSprite = Resources.Load<Sprite>("Red_Dot");


    }
}
