using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Invantory Object")]
public class InventoryObject : ScriptableObject {

    public GameObject objectPrefab;
    public Sprite objectImage;
    public string objectName;
}
