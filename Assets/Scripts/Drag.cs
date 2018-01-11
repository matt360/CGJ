using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Transform dragGameObject;
    //private LayerMask canDrag;
    //public LayerMask canDrag2;
    private Vector3 offset;
    private bool isClickCube;
    private Vector3 targetScreenPoint;

    // Use this for initialization
    private void Start()
    {
        //canDrag = 1 << LayerMask.NameToLayer("Cube");
    }


    private void Update()
    {
#if UNITY_EDITOR
        //for unity editor
        if (Input.GetMouseButtonDown(0))
        {
            if (CheckGameObjectMouse())
            {
                //Debug.Log(123);
                offset = dragGameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));
            }
        }

        if (isClickCube)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z);

            Vector3 curWorldPoint = Camera.main.ScreenToWorldPoint(curScreenPoint);
            if (dragGameObject)
                dragGameObject.position = curWorldPoint + offset;
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragGameObject = null;
            isClickCube = false;
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
                        offset = dragGameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, targetScreenPoint.z));
                    }
                    break;
                case TouchPhase.Canceled: // If the interaction ends for any reason, we have to call the listeners
                case TouchPhase.Ended:
                    dragGameObject = null;
                    isClickCube = false;
                    break;
            }
            
            if (isClickCube)
            {
                Vector3 curScreenPoint = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, targetScreenPoint.z);

                Vector3 curWorldPoint = Camera.main.ScreenToWorldPoint(curScreenPoint);
                if(dragGameObject)
                    dragGameObject.position = curWorldPoint + offset;
            }
        }

#endif
    }

    private bool CheckGameObjectTouch()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Beaker"
                    || hitInfo.collider.gameObject.tag == "Bottle"
                    || hitInfo.collider.gameObject.tag == "Erl_Flask"
                    || hitInfo.collider.gameObject.tag == "Measuring_Cylinder"
                    || hitInfo.collider.gameObject.tag == "Squeeze_Bottle"
                    || hitInfo.collider.gameObject.tag == "Flask_Small"
                    || hitInfo.collider.gameObject.tag == "Round_Bottomed_Flask")
                {
                    isClickCube = true;
                    dragGameObject = hitInfo.collider.GetComponent<Transform>();
                    targetScreenPoint = Camera.main.WorldToScreenPoint(dragGameObject.position);
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
            if (hitInfo.collider.gameObject.tag == "Beaker"
                || hitInfo.collider.gameObject.tag == "Bottle"
                || hitInfo.collider.gameObject.tag == "Erl_Flask"
                || hitInfo.collider.gameObject.tag == "Measuring_Cylinder"
                || hitInfo.collider.gameObject.tag == "Squeeze_Bottle"
                || hitInfo.collider.gameObject.tag == "Flask_Small"
                || hitInfo.collider.gameObject.tag == "Round_Bottomed_Flask")
            {
                isClickCube = true;
                dragGameObject = hitInfo.collider.GetComponent<Transform>();
                targetScreenPoint = Camera.main.WorldToScreenPoint(dragGameObject.position);
                return true;
            }
        }
        return false;
    }


}
