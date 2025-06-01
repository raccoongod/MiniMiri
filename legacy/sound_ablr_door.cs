using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_ablr_door     : MonoBehaviour
{

    private float timer = 0.0f;
    public float starttime, endtime,soundtime = 0.0f;
    private float scheck,checker = 0;
    
    public GameObject sound;
    // Use this for initialization
    void Start()
    {
        sound.SetActive(false);
    }
    void Update()
    {
        if(checker ==1)
            timer += Time.deltaTime;

        if (timer > endtime)
        {
            sound.SetActive(false);
            timer = 0;
            checker = 0;
            scheck = 0;
        }
        if (scheck == 1 && soundtime < timer)
        {
            sound.SetActive(false);
            scheck = 0;
        }
        if (timer > starttime && timer < endtime)
        {
            sound.SetActive(true);
        }

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider coll)
    {
        sound.SetActive(true);
        checker = 1;
        scheck = 1;

    }
}
