using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightItems : MonoBehaviour {

	public Transform Beaker;
    public Transform Bottle;
    public Transform Erl_Flask;
    public Transform Filter;
    public Transform Measuring_Cylinder;
    public Transform Scale;
    public Transform Spatula;
    public Transform Squeeze_Bottle;
    public Transform Flask_Small;
    public Transform Separate_Layers;
    public Transform Ring_Stand;
    public Transform Round_Bottomed_Flask;

    void OnTriggerStay(Collider collision)
    { 
        if (collision.tag == "Beaker")
            collision.gameObject.transform.position = Beaker.transform.position;

       
}


}
