using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDesSlot : MonoBehaviour
{
    public Image itemImage;
    public Text slotText;
  
    public bool SpriteOneIsChanged;
    public bool SpriteTwoIsChanged;
    public bool SpriteThreeIsChanged;
    public int check = 0;
    public float TimeToHide = 2.5f;

 
    void Start()
    {
        SetItem(null, null);
        SpriteOneIsChanged = false;
        SpriteTwoIsChanged = false;
        SpriteThreeIsChanged = false;
        gameObject.SetActive(false);
    }


    public void SetItem(Sprite image, string ItemName)
    {
        slotText.text = ItemName;
        itemImage.sprite = image;
        gameObject.SetActive(true);
    }
}
