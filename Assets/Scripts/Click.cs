using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject buttonmenu;
    public Transform equip;
    public Transform eleme;
    public LayerMask canDrag2;

    private LayerMask canDrag;
    private Vector3 offset;
    private bool isClickCube;
    private Vector3 targetScreenPoint;

    private bool isShow = false;
    private Vector3 startMarker;
    private Vector3 endMarker;
    private float speed = 10F;
    private float startTime;
    private float journeyLength;

    void Start()
    {

    }

    private void Update()
    {
#if UNITY_EDITOR
        //for unity editor
        if (Input.GetMouseButtonDown(0))
        {
            if (CheckGameObjectMouse())
            {
                startMarker = GameObject.FindGameObjectWithTag("1").transform.position;
                startTime = Time.time;
                journeyLength = Vector3.Distance(startMarker, endMarker);

            }
        }
#else
        //for android devices
        if (Input.touchCount > 0)
        {
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    if (CheckGameObjectTouch())
                    {
                        startMarker = GameObject.FindGameObjectWithTag("1").transform.position;
                        startTime = Time.time;
                        journeyLength = Vector3.Distance(startMarker, endMarker);
                    }
                    break;
                case TouchPhase.Canceled: // If the interaction ends for any reason, we have to call the listeners
                case TouchPhase.Ended:
                    break;
            }

        }

#endif
        if (isClickCube && journeyLength != 0)
        {
            //Debug.Log(1);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            GameObject.FindGameObjectWithTag("1").transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        }

        if (GameObject.FindGameObjectWithTag("1").transform.position == endMarker)
        {
            isClickCube = false;
        }



    }

    private bool CheckGameObjectTouch()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "UI")
                {
                    isShow = true;
                    endMarker = new Vector3(0, -6, 0);
                    buttonmenu.SetActive(false);
                    isClickCube = true;
                    switch (this.gameObject.name)
                    {
                        case "Equipment":
                            equip.gameObject.SetActive(true);
                            eleme.gameObject.SetActive(false);
                            break;
                        case "Element":
                            equip.gameObject.SetActive(false);
                            eleme.gameObject.SetActive(true);
                            break;
                    }
                    return true;
                }
                else if (hitInfo.collider.gameObject.tag == "Background" || hitInfo.collider.gameObject.tag == "ItemIcon")
                {
                    isShow = false;
                    endMarker = new Vector3(0, 0, 0);
                    buttonmenu.SetActive(true);
                    isClickCube = true;
                    return true;
                }
                
            }
        }
        return false;
    }

    private bool CheckGameObjectMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.tag == "UI")
            {
                //Debug.Log(1);
                isShow = true;
                endMarker = new Vector3(0, -6, 0);
                buttonmenu.SetActive(false);
                isClickCube = true;
                switch (this.name)
                {
                    case "EquipmentBtn":
                        Debug.Log(1);
                        equip.gameObject.SetActive(true);
                        eleme.gameObject.SetActive(false);
                        break;
                    case "ElementBtn":
                        Debug.Log(2);
                        equip.gameObject.SetActive(false);
                        eleme.gameObject.SetActive(true);
                        break;
                }
                //Debug.Log(hitInfo.collider.gameObject.name);
                return true;
            }
            else if (hitInfo.collider.gameObject.tag == "ItemIcon" || hitInfo.collider.gameObject.tag == "Background" || hitInfo.collider.gameObject.tag == "Item")
            {
                //Debug.Log(2);
                isShow = false;
                endMarker = new Vector3(0, 0, 0);
                buttonmenu.SetActive(true);
                isClickCube = true;
                
                return true;
            }
            Debug.Log(hitInfo.collider.gameObject.name);
        }
        return false;
    }
}
