using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(DestorySelf());
        
      
    }
    IEnumerator DestorySelf()
    {
        
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
