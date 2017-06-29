using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour {
    public RadialButton buttonPrefab;
    public bool autoSpaceButton;
    public int numberOfbutton = 6;
    public float buttonSize = 50f;
    public float distanceFromCenter = 50f;
    public Vector3 Rotate = new Vector3(0f, -2.5f, 0f);

    private RectTransform newButtonRect;

	// Use this for initialization
	void Start () {
        transform.GetChild(0).gameObject.GetComponent<RectTransform>().localScale = Vector3.zero;
        iTween.ScaleTo(transform.GetChild(0).gameObject, Vector3.one, 1f);
	}

    //public void SpawnButton(MaterialChange obj)
    public void SpawnButton(MenuController obj)
    {
        for(int i = 0; i < obj.menus.Length; i++)
        {
            RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
            newButton.transform.SetParent(transform.GetChild(0));
            newButton.transform.localScale = Vector3.one;
            newButton.transform.localEulerAngles = Rotate;

            newButtonRect = newButton.gameObject.GetComponent<RectTransform>();
            newButtonRect.sizeDelta = new Vector2(buttonSize, buttonSize);
            newButton.title = obj.menus[i].title;
            newButton.Event_Button = obj.menus[i].Event_Button;
            newButton.material = obj.icons[i].icon;
            newButton.obj = obj;
            /* Old Version
            float theta = (2 * Mathf.PI / obj.materials.Length) * i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * distanceFromCenter;
            */

            float theta = 0;
            if(autoSpaceButton == true)
            {
                theta = (2 * Mathf.PI / obj.menus.Length) * i;
            }
            else
            {
                theta = (2 * Mathf.PI / numberOfbutton) * i;
            }
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * distanceFromCenter;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
