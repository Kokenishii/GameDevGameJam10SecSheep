using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour {
    public float projectileSpeed=1;
   GameObject clockHandPlayer;
    public GameObject targetParticle;
    public Vector3 shootDirection;
    
	// Use this for initialization
	void Start () {
       
        clockHandPlayer = GameObject.Find("clockHandPlayer");
        shootDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * clockHandPlayer.transform.localEulerAngles.z),
                                   Mathf.Sin(Mathf.Deg2Rad * clockHandPlayer.transform.localEulerAngles.z),
                                                                                                        0);
      

        transform.localEulerAngles = new Vector3(0,0,clockHandPlayer.transform.localEulerAngles.z);
   

    }

    // Update is called once per frame
    void Update () {        
        transform.position += projectileSpeed*Time.deltaTime*shootDirection;

	}

    void OnCollisionEnter2D(Collision2D enemy)
    {
        GameObject targetClear = Instantiate(targetParticle) as GameObject;
        targetClear.transform.localPosition =transform.localPosition;

        targetClear.transform.localEulerAngles = new Vector3(-transform.localEulerAngles.z, 90, 0);
       
        if (enemy.gameObject.CompareTag("enemy"))
        {
            
            gameObject.SetActive(false);
            enemy.gameObject.SetActive(false);
        }
    }
   

}
