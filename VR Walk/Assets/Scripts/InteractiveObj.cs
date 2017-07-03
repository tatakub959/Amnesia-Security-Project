using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveObj : MonoBehaviour {
    public bool InteractiveObject = true;
    public float distance = 5;
    public float maxGazeTime = 1.5f;
    public float outLineWidth = 1f;
    public float outLineGrowSpeed = 2f;

    private Collider myCollider;
    private Transform playerTransform;
    private EventTrigger myTrigger;
    private GameObject outlineObj;
    private Material outlineMaterial;
    private MeshRenderer outlineRenderer;
    private int outlineStatus;
    private bool disableOnOutlineDestroy;
    private float outlineLerp;
    private float currentOutlineWidth;

    private float timer = 0;
    private bool isGazeAt = false;

    // Use this for initialization
    void Start () {
        outlineMaterial = Resources.Load("Materials/OutLineOnly") as Material;

        myCollider = gameObject.GetComponent<Collider>();

        playerTransform = Camera.main.transform;

        myTrigger = gameObject.GetComponent<EventTrigger>();

        if(myTrigger == null)
        {
            myTrigger = gameObject.AddComponent<EventTrigger>();
        }
        //Pointer Enter
        EventTrigger.Entry entryOver = new EventTrigger.Entry();
        entryOver.eventID = EventTriggerType.PointerEnter;
        entryOver.callback.AddListener((eventData) => { OnPointerEnter(); });
        myTrigger.triggers.Add(entryOver);

        //Pointer Exit
        EventTrigger.Entry entryOut = new EventTrigger.Entry();
        entryOut.eventID = EventTriggerType.PointerExit;
        entryOut.callback.AddListener((eventData) => { OnPointerExit(); });
        myTrigger.triggers.Add(entryOut);

        //Pointer Click
        EventTrigger.Entry entryClick = new EventTrigger.Entry();
        entryClick.eventID = EventTriggerType.PointerClick;
        entryClick.callback.AddListener((eventData) => { OnPointerClick(); });
        myTrigger.triggers.Add(entryClick);

        //Pointer Up
        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerUp;
        entryUp.callback.AddListener((eventData) => { OnPointerUp(); });
        myTrigger.triggers.Add(entryUp);

        //Pointer Down
        EventTrigger.Entry entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;
        entryDown.callback.AddListener((eventData) => { OnPointerDown(); });
        myTrigger.triggers.Add(entryDown);
    }

    // Update is called once per frame
    void Update () {
		if(InteractiveObject == false)
        {
            return;
        }else if (outlineStatus == 1)
        {
            if(outlineLerp < 1)
            {
                outlineLerp += Time.deltaTime * outLineGrowSpeed;
                currentOutlineWidth = Mathf.Lerp(0f, outLineWidth, outlineLerp);
                outlineRenderer.material.SetFloat("_Outline", currentOutlineWidth);
            }
        }else if (outlineStatus == 2)
        {
            if (outlineLerp >= 0)
            {
                outlineLerp -= Time.deltaTime * outLineGrowSpeed;
                currentOutlineWidth = Mathf.Lerp(0f, outLineWidth, outlineLerp);
                outlineRenderer.material.SetFloat("_Outline", currentOutlineWidth);
            }else if (outlineLerp <= 0f)
            {
                GameObject.Destroy(outlineObj);
                outlineStatus = 0;

                if(disableOnOutlineDestroy == true)
                {
                    InteractiveObject = false;
                    disableOnOutlineDestroy = false;
                }
            }
        }

        if (isGazeAt)
        {
            timer += Time.deltaTime;
            if(timer > maxGazeTime)
            {
                timer = 0;
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
                DisableInteraction();
            }
        }
        else if(timer != 0f)
        {
            timer -= Time.deltaTime;
            if(timer < 0f)
            {
                timer = 0f;
            }
        }
    }


    private void OnPointerEnter()
    {
        outlineStatus = 1;
        SpawnOutLineChild();
        isGazeAt = true;
    }

    private void OnPointerExit()
    {
        outlineStatus = 2;
        isGazeAt = false;
    }

    private void OnPointerClick()
    {
        
    }

    private void OnPointerUp()
    {
        
    }

    private void OnPointerDown()
    {
        
    }

    private void DisableInteraction()
    {
        outlineStatus = 2;
        disableOnOutlineDestroy = true;
        myCollider.enabled = false;
    }

    private void SpawnOutLineChild()
    {
        if(outlineObj != null)
        {
            GameObject.Destroy(outlineObj);
        }

        outlineObj = new GameObject(gameObject.name + "_Outline");
        outlineObj.transform.SetParent(transform);
        outlineObj.transform.localPosition = Vector3.zero;
        outlineObj.transform.localRotation = Quaternion.identity;
        outlineObj.transform.localScale = Vector3.one;
        outlineRenderer = outlineObj.AddComponent<MeshRenderer>();
        MeshFilter outlineFilter = outlineObj.AddComponent<MeshFilter>();
        outlineFilter.mesh = (Mesh)gameObject.GetComponent<MeshFilter>().mesh;
        outlineRenderer.material = outlineMaterial;
        outlineRenderer.material.SetFloat("_Outline", 0f);
        outlineLerp = 0;
    }
}
