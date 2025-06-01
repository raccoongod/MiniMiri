using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class move : MonoBehaviour {
    float h = 0.0f;
    float v = 0.0f;

    public float speed = 2.0f;
    Rigidbody rigid;
    Vector3 MoveDir;

    // Use this for initialization
    void Start () {
		
	}
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        Move(h, v);
	}
   void Move(float h,float v)
    {
        MoveDir.Set(h, 0, v);
        MoveDir = MoveDir.normalized * speed * Time.deltaTime;
        rigid.MovePosition(transform.position + MoveDir);

    }
}
