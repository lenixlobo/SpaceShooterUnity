    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    [SerializeField]
    private float speed = 2.5f;
    [SerializeField]
    private int powerupID;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0.0f,4.0f,0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down*Time.deltaTime*speed);
        if(transform.position.y<=-6.5f)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
        
        player playerer = other.GetComponent<player>();

            
                if (powerupID == 0)
                { 
                playerer.TripleShotPowerUpOn();
                }
                else if(powerupID==1)
                {
                    playerer.BoostPowerUpOn();
                }
                //else if(powerupID ==2)
                //{
                  //  playerer.
                //}
            
            
            Destroy(this.gameObject);
        }
        //Debug.Log("Collision with :" + other);
        //player player = GetComponent<player>();
        //player.canTripleShot = true;
        
    }
}
