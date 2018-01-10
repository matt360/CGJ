using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
    private Transform dragGameObject;
    private LayerMask canDrag;
    public LayerMask canDrag2;
    private Vector3 offset;
    private bool isClickCube;
    private Vector3 targetScreenPoint;

    // Use this for initialization
    private void Start()
    {
        canDrag = 1 << LayerMask.NameToLayer("Cube");
    }

#if UNITY_EDITOR
    //for unity editor
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CheckGameObject())
            {
                offset = dragGameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z));
            }
        }

        if (isClickCube)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPoint.z);

            Vector3 curWorldPoint = Camera.main.ScreenToWorldPoint(curScreenPoint);
            dragGameObject.position = curWorldPoint + offset;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isClickCube = false;
        }

    }
    
    private bool CheckGameObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Debug.Log(11);
            isClickCube = true;
            dragGameObject = hitInfo.collider.gameObject.transform;
            targetScreenPoint = Camera.main.WorldToScreenPoint(dragGameObject.position);
            return true;
        }
        return false;
    }
#else
    //for android devices

#endif
}
