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
        if (other.gameObject.tag == "Beaker"
                    || other.gameObject.tag == "Element"
                    || other.gameObject.tag == "Erl_Flask"
                    || other.gameObject.tag == "Measuring_Cylinder"
                    || other.gameObject.tag == "Squeeze_Bottle"
                    || other.gameObject.tag == "Flask_Small"
                    || other.gameObject.tag == "Round_Bottomed_Flask"
                    || other.gameObject.tag == "Spatula")
        {
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
