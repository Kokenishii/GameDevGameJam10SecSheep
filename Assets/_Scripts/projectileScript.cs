using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {
    public float projectileSpeed=1;
   GameObject clockHandPlayer;
    public Vector3 shootDirection;
    
	// Use this for initialization
	void Start () {
       
        clockHandPlayer = GameObject.Find("clockHandPlayer");
        shootDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad*clockHandPlayer.transform.localEulerAngles.z), 
                                   Mathf.Sin(Mathf.Deg2Rad * clockHandPlayer.transform.localEulerAngles.z), 
                                                                                                        0);
    }
	
	// Update is called once per frame
	void Update () {

//Debug.Log(clockHandPlayer.transform.localRotation.z);
        transform.position += projectileSpeed*Time.deltaTime*shootDirection;

       
	}

    void OnCollisionEnter2D(Collision2D enemy)
    {
        Debug.Log("collide!");
        gameObject.SetActive(false);
        if(enemy.gameObject.CompareTag("enemy"))
        enemy.gameObject.SetActive(false);
    }
}
