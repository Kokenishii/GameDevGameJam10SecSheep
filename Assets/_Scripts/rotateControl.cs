using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateControl : MonoBehaviour {
    float leftRight;
    public float moveConstant=1;
    public GameObject projectilePrefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        leftRight = -Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0,0,leftRight*moveConstant));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectileCreated = Instantiate(projectilePrefab) as GameObject;
        }

    }
}
