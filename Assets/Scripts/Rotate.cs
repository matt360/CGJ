using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    private float speed,rotate;
	// Use this for initialization
	void Start () {
        speed = 100.0f;
        rotate = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        rotate += Time.deltaTime * speed;
        this.transform.rotation= Quaternion.Euler(0,rotate,0);
    }
}
