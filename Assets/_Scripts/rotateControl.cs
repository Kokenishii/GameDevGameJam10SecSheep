using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateControl : MonoBehaviour {
    float leftRight;
    public float moveConstant=1;
    public GameObject projectilePrefab;
    public GameObject handClicked;
    public bool canMove = true;
    public bool canShoot = true;
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
            handClicked.gameObject.SetActive(true);
            StartCoroutine(shootHighlight());
            if (canShoot)
            {
                GameObject projectileCreated = Instantiate(projectilePrefab) as GameObject;
            }
            canMove = false;
           // StartCoroutine(move());
        }
        else
        {
            if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
            {
                canMove = false;
            }
            else
            {
               canMove = true;
            }
        }
      

    }
    IEnumerator move()
    {

        yield return new WaitForSeconds(0.5f);
        canMove = true;
        
    }
    IEnumerator shootHighlight()
    {
        yield return new WaitForSeconds(0.1f);

        handClicked.gameObject.SetActive(false);
    }
}
