using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private float speed = 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //move down
        transform.Translate(Vector3.down*Time.deltaTime*speed);
        //when off the screen
        if(transform.position.y<-5.0f)
        {
            transform.position = new Vector3(Random.Range(-7.0f,7.0f),4.50f,transform.position.z);
        }
        //respawn at the bottom
}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
           
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        else if(other.tag == "Player")
        {
            player playerer = other.GetComponent<player>();
            if (playerer != null)
            {
                playerer.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
