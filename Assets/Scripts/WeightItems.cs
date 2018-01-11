using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightItems : MonoBehaviour {

	public Transform weightingPlace;
    public Transform itemWeightingPlace;

    //void OnCollisionEnter(Collision coll) {
    //	if (coll.gameObject.tag == "Item")
    //		coll.gameObject.transform.position = weightingPlace.transform.position;
    //	Debug.Log ("collision happened");
    //}

    void OnTriggerStay(Collider collision)
    { 
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    collision.transform.position = weightingPlace.transform.position;
        //}
        //if (collision.gameObject.tag == "Item")
        collision.gameObject.transform.position = weightingPlace.transform.position;


        Debug.Log("Collision happened");
    }


}
