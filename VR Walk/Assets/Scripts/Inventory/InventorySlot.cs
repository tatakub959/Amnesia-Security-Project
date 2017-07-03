using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    public Image itemImage;
    public Text slotText;
    //public bool SpriteIsChanged;
    public bool SpriteOneIsChanged;
    public bool SpriteTwoIsChanged;
    public bool SpriteThreeIsChanged;
    public int check = 0;
    public float TimeToHide = 2.5f;

    // Use this for initialization
    void Start () {
        //slotText = GetComponentInChildren<Text>();
        SetItem(null, null);
       // SpriteIsChanged = false;
        SpriteOneIsChanged = false;
        SpriteTwoIsChanged = false;
        SpriteThreeIsChanged = false;
        gameObject.SetActive(false);
    }


    public void SetItem(Sprite image, string ItemName)
    {
        /*
        if (image == null)
            itemImage.enabled = false;
        else if (itemImage.enabled == false)
            itemImage.enabled = true;
        itemImage.sprite = image;
        */

        slotText.text = ItemName;
        itemImage.sprite = image;
        //SpriteIsChanged = true;
        /*
        if (check == 0) SpriteOneIsChanged = true;
        
        if (check == 1) SpriteTwoIsChanged = true;

        if (check >= 2) SpriteThreeIsChanged = true;
        */

        /**
        if (image != null)
        {
            itemImage.enabled = true;
            gameObject.SetActive(true);
        }*/
        gameObject.SetActive(true);


        //itemImage.GetComponent<Image>().overrideSprite = image;
        //slotText.text = quantity == 0 ? "" : quantity.ToString();
    }
    /*
    private void Update()
    {
        TimeToHide -= Time.deltaTime;
        if(TimeToHide <= 0) gameObject.SetActive(true);
        Debug.Log("Time from IP PORT:" + TimeToHide);
    }*/
}
