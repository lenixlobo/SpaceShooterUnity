using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    [SerializeField]
    private float speed = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //move up
        transform.Translate(Vector3.up*Time.deltaTime*speed);      
        if(transform.position.y > 6.0f)
        {
            Destroy(this.gameObject);
        }
 
	}


}
