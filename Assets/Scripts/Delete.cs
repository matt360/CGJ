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
        if (other.gameObject.tag == "Item" || other.gameObject.tag == "Element")
        {
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
