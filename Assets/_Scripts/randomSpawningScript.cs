using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawningScript : MonoBehaviour {
	int timer;
	public GameObject enemyPrefab;
	float radius;
	GameObject circle;
	List<GameObject> spawnedObjectsQ1;
	List<GameObject> spawnedObjectsQ2;
	List<GameObject> spawnedObjectsQ3;
	List<GameObject> spawnedObjectsQ4;

	// Use this for initialization
	void Start () {	
		spawnedObjectsQ1 = new List<GameObject>();
		spawnedObjectsQ2 = new List<GameObject>();
		spawnedObjectsQ3 = new List<GameObject>();
		spawnedObjectsQ4 = new List<GameObject>();

//		GameObject circle = GameObject.Find ("ClockCenter").transform.FindChild ("clockBase").gameObject;
		circle = transform.parent.gameObject;
		radius = circle.GetComponent<SpriteRenderer> ().bounds.extents.x;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer++;
		if (timer == 50) {
			timer = 0;

			for (int i = 0; i < 3; i++) {
				bool successful = spawnInAngleRange (-45, 45, spawnedObjectsQ1);
				if (!successful) {
					i -= 1;
				}
			}

			for (int i = 0; i < 3; i++) {
				bool successful = spawnInAngleRange (45, 135, spawnedObjectsQ2);
				if (!successful) {
					i -= 1;
				}
			}

			for (int i = 0; i < 3; i++) {
				bool successful = spawnInAngleRange (135, 225, spawnedObjectsQ3);
				if (!successful) {
					i -= 1;
				}
			}

			for (int i = 0; i < 3; i++) {
				bool successful = spawnInAngleRange (225, 315, spawnedObjectsQ4);
				if (!successful) {
					i -= 1;
				}
			}



		}
	}

	bool spawnInAngleRange(float min, float max, List<GameObject> objectList) {
		// dangerous. if you fuck with the 9 down here you run the risk of crashing unity
		if (objectList.Count >= 9) {
			return true;
		}

		// shit for Q1
		bool deaded = false;
		//				float angle = 45;

		float angle = Random.Range (max, min);
		//				Debug.Log (angle);
		//				Vector3 anglePos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

		Vector3 targetDir = new Vector3 (0, 1, 0);
//		targetDir = targetDir.normalized;
		//				Debug.Log (targetDir);
		Quaternion rotate = Quaternion.Euler(0,0,angle);
		Vector3 pivot = transform.position;
		targetDir = rotate * (targetDir - pivot) + pivot;
		Vector3 randomPos = targetDir * Random.Range(1, radius);
//		Vector3 randomPos = targetDir * radius;

		//				Debug.Log (randomPos);

		GameObject enemy = Instantiate (enemyPrefab, randomPos, Quaternion.identity) as GameObject;

		for (int j = 0; j < objectList.Count; j++) {
			Bounds checkingAgainst = objectList[j].GetComponent<SpriteRenderer> ().bounds;
			Bounds checking = enemy.GetComponent<SpriteRenderer> ().bounds;
			if (checking.Intersects(checkingAgainst)) {
				Debug.Log ("ayyy");
				deaded = true;
				GameObject.Destroy (enemy);
				break;
			}
		}

		if (deaded) {
			return !deaded;
		}

		objectList.Add (enemy);

		return !deaded;
		
	}
}
