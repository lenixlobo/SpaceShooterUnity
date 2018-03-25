using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    [SerializeField]
    private GameObject laserprefab;
    [SerializeField]
    private GameObject Tripleprefab;
    public int lives =3;

    public float canfire;
    public float fireRate;
    public bool canTripleShot = false;
    public bool canBoost = false;
    public bool canShield = false;
    [SerializeField]
    private float speed = 8.0f;
    //public float horizontal_input;
	// Use this for initialization
	void Start () {
        //Debug.Log("x pos:" + transform.position.x);
        //Debug.Log("y pos: " + transform.position.y);
        transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(Time.time>canfire)
            {
                if (canTripleShot)
                {
                    Instantiate(Tripleprefab,transform.position,Quaternion.identity);
                    /*
                    Instantiate(laserprefab, transform.position + new Vector3(0.45f, -0.65f, 0), Quaternion.identity);
                    Instantiate(laserprefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                    Instantiate(laserprefab, transform.position + new Vector3(-0.45f, -0.65f, 0), Quaternion.identity);
                    canfire = Time.time + fireRate;
                    */
                }

                else
                { 
                    Instantiate(laserprefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                    canfire = Time.time + fireRate;
                }

            }
            //spawn laser
            
        }
      
    }
    private void Movement()
    {
        //speed += 0.5f;
        float horizontal_input = Input.GetAxis("Horizontal");//add horizontal movement
        float vertical_input = Input.GetAxis("Vertical");//add vertical movement
        if (canBoost)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 15.0f * horizontal_input);
            transform.Translate(Vector3.up * Time.deltaTime * 15.0f * vertical_input);
        }
        else
        {
            transform.Translate(new Vector3(speed * horizontal_input, speed * vertical_input, 0) * Time.deltaTime); ;
        }
        
        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontal_input);
        //transform.Translate(Vector3.up * Time.deltaTime * speed * vertical_input);
        if (transform.position.y > 0.0f)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }
        else if (transform.position.x < -9)
        {
            transform.position = new Vector3(9, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        lives -= 1;
        if (lives<1)
        {
            Destroy(this.gameObject);
        }
        
    }
    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    public void BoostPowerUpOn()
    {
        canBoost = true;
        StartCoroutine(BoostSpeedRoutine());
    }
    public IEnumerator BoostSpeedRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canBoost = false;
    }
}
