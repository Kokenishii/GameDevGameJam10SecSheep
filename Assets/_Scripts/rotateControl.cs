using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateControl : MonoBehaviour {
    float leftRight;
    public float moveConstant=1;
    public GameObject projectilePrefab;
    public bool canMove = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove)
            {
            leftRight = -Input.GetAxis("Horizontal");
            transform.Rotate(new Vector3(0, 0, leftRight * moveConstant));
        }
   
        //transform.Rotate(new Vector3(0,0,leftRight*moveConstant));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GameObject projectileCreated = Instantiate(projectilePrefab) as GameObject;
            canMove = false;
           // StartCoroutine(move());
        }
        else
        {
           
        }
      

    }
    IEnumerator move()
    {

        yield return new WaitForSeconds(0.5f);
        canMove = true;
        
    }
}
