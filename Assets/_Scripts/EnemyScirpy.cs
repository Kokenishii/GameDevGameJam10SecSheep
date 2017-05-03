using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScirpy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject circle = GameObject.Find ("ClockCenter").transform.FindChild ("clockBase").gameObject;
		float radius = circle.GetComponent<SpriteRenderer> ().bounds.extents.x;
		transform.position = Random.insideUnitCircle * Random.Range (1, radius);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
