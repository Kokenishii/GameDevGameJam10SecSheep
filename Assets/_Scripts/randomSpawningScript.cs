using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawningScript : MonoBehaviour {
	int timer;
	public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {	
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if (timer == 150) {
			timer = 0;
			for (int i = 0; i < 10; i++) {
				GameObject enemy = Instantiate (enemyPrefab) as GameObject;
			}
		}
	}
}
