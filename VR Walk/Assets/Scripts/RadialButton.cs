using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialButton : MonoBehaviour
{
    [HideInInspector]
    public string title;

    [HideInInspector]
    public Material material;
    public Button Event_Button;

    [HideInInspector]
    //public MaterialChange obj;
    public MenuController obj;

    private MeshRenderer childRenderer;

    private GameObject InSideButton;
    public Vector3 InSideButton_Size = new Vector3(20f, 0.5f, 20f);
    //public Vector3 ButtonPosition = new Vector3(0f, 35f, -2f);

    //Add--------------------------------------------------------
    public Image progressImage;
    public bool isEntered = false;
    float timeElapsed;
    public float GazeActivationTime = 2.0f;

    // Use this for initialization
    void Start()
    {
        
        childRenderer = transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        childRenderer.material = material;
        
        InSideButton = this.gameObject.transform.GetChild(0).gameObject;
        InSideButton.transform.localScale = InSideButton_Size;
        //this.gameObject.transform.localPosition = ButtonPosition;
        //childRenderer = transform.GetChild(0).localScale;

    }

    void Awake()
    {
        Event_Button = GetComponent<Button>();

    }
    public void OnPointerEnter()
    {
        obj.pointOverbutton = true;
        //Event_Button.onClick.Invoke();
        isEntered = true;
    }

    public void OnPointerExit()
    {
        obj.pointOverbutton = false;
        StartCoroutine(obj.TryToDestroyMenu());
        isEntered = false;
    }

    public void OnPointerDown()
    {
        //Event_Button.onClick.Invoke();
        isEntered = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (isEntered)
        {
            timeElapsed += Time.deltaTime;
            progressImage.fillAmount = Mathf.Clamp(timeElapsed / GazeActivationTime, 0, 1);
            if (timeElapsed >= GazeActivationTime)
            {
                timeElapsed = 0;
                Event_Button.onClick.Invoke();
                progressImage.fillAmount = 0;
                isEntered = false;
            }
        }
        else
        {
            progressImage.fillAmount = 0;
            timeElapsed = 0;
        }
    }
}
