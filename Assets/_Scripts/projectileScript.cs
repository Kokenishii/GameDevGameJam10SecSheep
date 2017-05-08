using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {
    public float projectileSpeed=1;
   GameObject clockHandPlayer;
    public GameObject targetParticle;
    public Vector3 shootDirection;
    public float initialV = 1f;
    public float continueV = 10f;
    public bool projectileAlive;
    public GameObject vortexRef;
   // public GameObject background;
   // public Color setColor;
	// Use this for initialization
	void Start () {
       
        clockHandPlayer = GameObject.Find("clockHandPlayer");
        shootDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * clockHandPlayer.transform.localEulerAngles.z),
                                   Mathf.Sin(Mathf.Deg2Rad * clockHandPlayer.transform.localEulerAngles.z),
                                                                                                        0);
      

        transform.localEulerAngles = new Vector3(0,0,clockHandPlayer.transform.localEulerAngles.z);
        projectileAlive = true;
       

    }

    // Update is called once per frame
    void Update () {
    
        // transform.position += projectileSpeed*Time.deltaTime*shootDirection;
        Rigidbody2D bullet = gameObject.GetComponent<Rigidbody2D>();
        bullet.AddForce(shootDirection * initialV, ForceMode2D.Impulse);
        bullet.AddForce(shootDirection*continueV, ForceMode2D.Force);
        //Test Here!!!!!!!!!!!!!!!
       // clockHandPlayer.GetComponent<rotateControl>().canMove = false;
        clockHandPlayer.GetComponent<rotateControl>().canShoot = false;
        //Test Here!!!!!!!!!!!!!!!
    }

    void OnCollisionEnter2D(Collision2D enemy)
    {
       vortexRef.SetActive(false);
        //Test Here!!!!!!!!!!!!!!! //Test Here!!!!!!!!!!!!!!! //Test Here!!!!!!!!!!!!!!!
        clockHandPlayer.GetComponent<rotateControl>().canMove = true;
        clockHandPlayer.GetComponent<rotateControl>().canShoot = true;
        //Test Here!!!!!!!!!!!!!!! //Test Here!!!!!!!!!!!!!!! //Test Here!!!!!!!!!!!!!!!
        GameObject targetClear = Instantiate(targetParticle) as GameObject;
        targetClear.transform.localPosition =transform.localPosition;

        targetClear.transform.localEulerAngles = new Vector3(-transform.localEulerAngles.z, 90, 0);
     gameObject.SetActive(false);
     
        if (enemy.gameObject.CompareTag("enemy"))
        {
            projectileAlive = false;
          //  background.GetComponent<SpriteRenderer>().color = setColor;
            gameObject.SetActive(false);
            enemy.gameObject.SetActive(false);

			GameObject.Find("RandomGenerateShit").GetComponent<randomSpawningScript>().numKilled += 1;
        }
    }
   

}
