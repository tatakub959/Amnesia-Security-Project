using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour {

    public RadialMenu menuPrefab;
    public Renderer objectToChange;

    [HideInInspector]
    public bool pointOverbutton, pointOverMenu;

    [System.Serializable]
    public class MaterialInfo
    {
        public string title;
        public Material material;
    }

    public MaterialInfo[] materials;

    private RadialMenu currentMenu;
    private Transform childCollider;
	
	void Start () {
        childCollider = transform.GetChild(0);
	}
	
    public void OnPointerEnter()
    {
        Debug.Log("Point IN !!!!!!");
        pointOverMenu = true;
        //Spawn menu;
        if(currentMenu == null)
        {
            currentMenu = Instantiate(menuPrefab) as RadialMenu;
            currentMenu.transform.position = transform.position;
            childCollider.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            //Spawn Button;
            //currentMenu.SpawnButton(this);
        }
    }
	
    public void OnPointerExit()
    {
        Debug.Log("Point OUTTTTTTT");
        pointOverMenu = false;
        StartCoroutine(TryToDestroyMenu());
    }
    public IEnumerator TryToDestroyMenu()
    {
        yield return new WaitForEndOfFrame();
        if(pointOverbutton == false && pointOverMenu == false)
        {
            //Destroy(currentMenu.gameObject);
            //childCollider.localScale = new Vector3(0.6268559f, 0.6268559f, 0.6268559f);
            childCollider.gameObject.SetActive(false);
            iTween.ScaleTo(currentMenu.transform.GetChild(0).gameObject, iTween.Hash("Scale", Vector3.zero, "time", 1f, "oncomplete", "DestroyMenu", "oncompletetarget", gameObject));
        }
    }

    private void DestroyMenu()
    {
        Destroy(currentMenu.gameObject);
        childCollider.localScale = new Vector3(0.6268559f, 0.6268559f, 0.6268559f);
        childCollider.gameObject.SetActive(true);
    }

}
