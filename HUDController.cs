using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{

    public GameObject HUD;
    public float timelimit = 2f;
    private float timer = 0;
    private static float again = 1;


    // Use this for initialization
    void Start()
    {
        if(again == 0)
        {
            HUD.SetActive(false);
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if(timer> timelimit)
        {
            again = 0;
            HUD.SetActive(false);
        }
            
    }
}

