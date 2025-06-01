using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    // 오브젝트의 이동속도
    public float speed = 100.0f;
    float h = 0.0f;
    float v = 0.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        v++;
        /*
        Vector3 moveDirection = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection (moveDirection);
        moveDirection *= Time.deltaTime * speed;
        moveDirection += transform.position;

        this.transform.position = moveDirection;
        */

        // transform.Translate() 를 사용하여 코드를 하나로 표현한 것.
        //Vector3 moveDirection = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //this.transform.Translate (moveDirection * Time.deltaTime * speed);

        // 코드를 하나에 전부 표현한 것.
        this.transform.Translate(new Vector3(h, 0 ,v ) * Time.deltaTime * speed);

        // rorate gameObjects
        if (Input.GetKey(KeyCode.A))
        {
            float key = speed * Time.deltaTime;
             this.transform.rotation *= Quaternion.AngleAxis (key, Vector3.down);
            print("The Q key is pressed for rotating the gameObject.");
        }

        if (Input.GetKey(KeyCode.D))
        {
            float key = speed * Time.deltaTime;
             this.transform.rotation *= Quaternion.AngleAxis (key, Vector3.up);
            print("The E key is pressed for rotating the gameObject.");
        }
        if (Input.GetKey(KeyCode.Q))
        {
            float key = speed * Time.deltaTime;
            this.transform.rotation *= Quaternion.AngleAxis(key, Vector3.right);
            print("The Q key is pressed for rotating the gameObject.");
        }

        if (Input.GetKey(KeyCode.E))
        {
            float key = speed * Time.deltaTime;
            this.transform.rotation *= Quaternion.AngleAxis(key, Vector3.left);
           
            print("The E key is pressed for rotating the gameObject.");
        }
     
    }
}

