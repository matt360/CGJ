using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightItems : MonoBehaviour
{

    public Transform Beaker;
    public Transform Bottle;
    public Transform Erl_Flask;
    public Transform Filter;
    public Transform Measuring_Cylinder;
    public Transform Spatula;
    public Transform Squeeze_Bottle;
    public Transform Flask_Small;
    public Transform Separate_Layers;
    public Transform Ring_Stand;
    public Transform Round_Bottomed_Flask;

    void OnTriggerStay(Collider collision)
    {
        switch (collision.tag)
        {
            case "Beaker":
                collision.gameObject.transform.position = Beaker.transform.position;
                break;

            case "Bottle":
                collision.gameObject.transform.position = Bottle.transform.position;
                break;

            case "Erl_Flask":
                collision.gameObject.transform.position = Erl_Flask.transform.position;
                break;

            case "Filter":
                collision.gameObject.transform.position = Filter.transform.position;
                break;

            case "Measuring_Cylinder":
                collision.gameObject.transform.position = Measuring_Cylinder.transform.position;
                break;

            case "Spatula":
                collision.gameObject.transform.position = Spatula.transform.position;
                break;

            case "Squeeze_Bottle":
                collision.gameObject.transform.position = Squeeze_Bottle.transform.position;
                break;

            case "Flask_Small":
                collision.gameObject.transform.position = Flask_Small.transform.position;
                break;

            case "Separate_Layers":
                collision.gameObject.transform.position = Separate_Layers.transform.position;
                break;

            case "Ring_Stand":
                collision.gameObject.transform.position = Ring_Stand.transform.position;
                break;

            case "Round_Bottomed_Flask":
                collision.gameObject.transform.position = Round_Bottomed_Flask.transform.position;
                break;
        }
    }

}
