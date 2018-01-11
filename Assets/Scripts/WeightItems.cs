using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightItems : MonoBehaviour {

	public Transform weightingPlace;
    public Transform itemWeightingPlace;

    void OnTriggerStay(Collider collision)
    { 
        collision.gameObject.transform.position = weightingPlace.transform.position;
    }


}
