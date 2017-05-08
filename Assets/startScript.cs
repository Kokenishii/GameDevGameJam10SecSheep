using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    public GameObject text;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Next());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Next()
    {

        yield return new WaitForSeconds(2);
        first.SetActive(false);
        second.SetActive(true);
        text.SetActive(true);     
    }
    
}