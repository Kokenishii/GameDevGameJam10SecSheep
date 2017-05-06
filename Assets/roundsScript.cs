using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundsScript : MonoBehaviour {
	public int roundsCompleted = -1;
	public Text roundsText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		roundsText.text = roundsCompleted.ToString ();
	}
}
