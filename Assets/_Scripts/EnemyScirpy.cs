using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScirpy : MonoBehaviour {

	// Use this for initialization
	public bool collidingWithOtherShit = false;
	void Start () {
		StartCoroutine (CheckForCollision());
		GameObject circle = GameObject.Find ("ClockCenter").transform.FindChild ("clockBase").gameObject;
		float radius = circle.GetComponent<SpriteRenderer> ().bounds.extents.x;

//		transform.position = Random.insideUnitCircle * Random.Range (1, radius);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D item) {
//		Debug.Log ("collided");	
		collidingWithOtherShit = true;
	}

	IEnumerator CheckForCollision() {
		yield return null;
//		Debug.Log ("collided");

	}
}
