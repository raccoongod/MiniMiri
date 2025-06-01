using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundablr : MonoBehaviour {

    public float timer = 0.0f;
    public float starttime, endtime = 0.0f;
    public GameObject sound;
    // Use this for initialization
    void Start () {
        sound.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer> starttime && timer< endtime)
        {
            sound.SetActive(true);
        }
        if (timer> endtime)
        {
            sound.SetActive(false);
            timer = 0;
        }
    }
}
