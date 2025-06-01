using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aninopendoor2f : MonoBehaviour {

    public Transform door;
    public float a = 0;
    void OnTriggerEnter(Collider coll)
    {
        
            a = 1;
            door.GetComponent<Animation>().Play("anindoor2f");
        
    }
}
