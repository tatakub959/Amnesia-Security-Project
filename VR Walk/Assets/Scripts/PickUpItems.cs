using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InteractiveObj))]
public class PickUpItems : MonoBehaviour
{
    public InventoryObject objectRefrence;
    public Button[] Items;

    //public Vector3 handPosition;
    //public Vector3 handRotation;

    private Transform vrCam;
    private Transform handMountingPosition;
    private int count_item1 = 0;
    private int count_item2 = 0;
    private int count_item3 = 0;
    //private GameObject changeSprite;

    void Start()
    {
        vrCam = Camera.main.transform;
        handMountingPosition = vrCam.GetChild(1);
       
    }

    public void MoveToPlayerHand()
    {
        transform.parent = handMountingPosition;
        gameObject.SetActive(false);

        if (Items[0].GetComponent<InventorySlot>().SpriteOneIsChanged == false && count_item1 == 0 && count_item2 == 0 && count_item3 == 0)
            {
                Items[0].GetComponent<InventorySlot>().SetItem(objectRefrence.objectImage, objectRefrence.objectName);
                Items[0].GetComponent<InventorySlot>().SpriteOneIsChanged = true;
                count_item1++;

                Debug.Log("count_item1: " + count_item1);
                Debug.Log("count_item2: " + count_item2);
                Debug.Log("count_item3: " + count_item3);
        }



        if (Items[1].GetComponent<InventorySlot>().SpriteTwoIsChanged == false && count_item1 == 0 && count_item2 == 0 && count_item3 == 0)
            {
                Items[1].GetComponent<InventorySlot>().SetItem(objectRefrence.objectImage, objectRefrence.objectName);
                Items[1].GetComponent<InventorySlot>().SpriteTwoIsChanged = true;
                count_item2++;

                Debug.Log("count_item1: " + count_item1);
                Debug.Log("count_item2: " + count_item2);
                Debug.Log("count_item3: " + count_item3);
        }

        if (Items[2].GetComponent<InventorySlot>().SpriteThreeIsChanged == false && count_item1 == 0 && count_item2 == 0 && count_item3 == 0)
            {
                Items[2].GetComponent<InventorySlot>().SetItem(objectRefrence.objectImage, objectRefrence.objectName);
                Items[2].GetComponent<InventorySlot>().SpriteThreeIsChanged = true;
                count_item3++;

                Debug.Log("count_item1: " + count_item1);
                Debug.Log("count_item2: " + count_item2);
                Debug.Log("count_item3: " + count_item3);
        }
          
    }

    /*
    public void UpdateSprite(CollectableObject obj)
    {
        //int idx = objectsInInvantory.FindIndex(x => x.name == obj.objectRefrence.name);
        //objectsInInvantory.Add(obj.objectRefrence);
        changeSprite.GetComponent<InventorySlot>().SetItem(obj.objectRefrence.objectImage);
    }*/
}
