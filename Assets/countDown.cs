using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class countDown : MonoBehaviour {
    float time=10;
    public Text countdownText;
    int timeText;
	// Use this for initialization
	void Start () {
        time = 10;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        timeText = Mathf.CeilToInt(time);
        countdownText.text = timeText.ToString();
        if (time<=0)
        {
            SceneManager.LoadScene(0);
        }
        Debug.Log(time);
    }
   
}
