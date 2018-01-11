using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {

	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("stay");
        if (hitInfo.collider.gameObject.tag == "Beaker"
                    || hitInfo.collider.gameObject.tag == "Bottle"
                    || hitInfo.collider.gameObject.tag == "Erl_Flask"
                    || hitInfo.collider.gameObject.tag == "Measuring_Cylinder"
                    || hitInfo.collider.gameObject.tag == "Squeeze_Bottle"
                    || hitInfo.collider.gameObject.tag == "Flask_Small"
                    || hitInfo.collider.gameObject.tag == "Round_Bottomed_Flask"
                    || hitInfo.collider.gameObject.tag == "Spatula")
        {
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
