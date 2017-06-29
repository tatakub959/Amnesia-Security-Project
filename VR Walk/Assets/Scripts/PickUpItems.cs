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
    private int count = 0;
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
    
            if (Items[count].GetComponent<InventorySlot>().SpriteIsChanged == false)
            {
                Items[count].GetComponent<InventorySlot>().SetItem(objectRefrence.objectImage, objectRefrence.objectName);
            }
            else
            {
                Items[count + 1].GetComponent<InventorySlot>().SetItem(objectRefrence.objectImage, objectRefrence.objectName);
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
