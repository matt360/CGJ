using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spetular : MonoBehaviour {
    public static int elementOnSpe = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (elementOnSpe > 1)
            elementOnSpe = 1;
        if (elementOnSpe < 0)
            elementOnSpe = 0;

        Debug.Log(elementOnSpe);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bottle")
        {
            elementOnSpe++;
        }
        else if(other.gameObject.tag == "Beaker"
            || other.gameObject.tag == "Erl_Flask"
                    || other.gameObject.tag == "Measuring_Cylinder"
                    || other.gameObject.tag == "Squeeze_Bottle"
                    || other.gameObject.tag == "Flask_Small"
                    || other.gameObject.tag == "Round_Bottomed_Flask")
        {
            elementOnSpe--;
        }
    }
}
