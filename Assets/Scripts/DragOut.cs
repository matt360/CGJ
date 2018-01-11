using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragOut : MonoBehaviour
{

    public GameObject prefabs;
    private Vector3 offset;
    private bool isClick;
    private Vector3 targetScreenPoint;
    private GameObject dragOutGameObject;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CheckGameObjectMouse())
            {
                //Debug.Log(123);
                offset = dragOutGameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));
            }
        }

        if (isClick)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z);
            Vector3 curWorldPoint = Camera.main.ScreenToWorldPoint(curScreenPoint);
            dragOutGameObject.transform.position = curWorldPoint + offset;
            //Debug.Log(curWorldPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragOutGameObject = null;
            isClick = false;
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
                if (hitInfo.collider.gameObject.tag == "ItemIcon")
                {
                    isClick = true;
                    switch (hitInfo.collider.gameObject.name)
                    {
                        case "Items":
                            dragOutGameObject = Instantiate(prefabs);
                            dragOutGameObject.transform.position = hitInfo.collider.gameObject.transform.position;
                            targetScreenPoint = Camera.main.WorldToScreenPoint(dragOutGameObject.transform.position);
                            break;
                        case "":
                            break;
                        default:
                            return false;
                    }
                    return true;
                }
            }
        }
        return false;
    }

    private bool CheckGameObjectMouse()
    {
        //Vector3 moupos=Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.tag == "ItemIcon")
            {
                isClick = true;
                switch (hitInfo.collider.gameObject.name)
                {
                    case "Items":
                        dragOutGameObject = Instantiate(prefabs);
                        dragOutGameObject.transform.position = hitInfo.collider.gameObject.transform.position;
                        targetScreenPoint = Camera.main.WorldToScreenPoint(dragOutGameObject.transform.position);
                        break;
                    case "":
                        break;
                    default:
                        return false;
                        break;
                }
                return true;
            }
        }
        return false;
    }
}
