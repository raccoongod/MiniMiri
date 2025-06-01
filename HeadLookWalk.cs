using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookWalk : MonoBehaviour {
    public float velocity = 0.7f;
    public bool isWorking = false;
    //ButtonExecute button = new ButtonExecute();
    private CharacterController controller;
    private Clicker clicker = new Clicker();
    public MoveButtonExecute Exe;
    private bool active = true;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
	}

    
// Update is called once per frame
void Update () {
        if(MoveButtonExecute.MSActive==1)
        {
            active = false;

        }
        else if(MoveButtonExecute.MSActive==0)
        {
            active = true;
        }
        //if(clicker.clocked())
        //{
        //    isWorking = !isWorking;
        //}
        //if(isWorking&& active == true)
        //{
        //    controller.SimpleMove(Camera.main.transform.forward * velocity);
        //}
        if ( active == true)
        {
            controller.SimpleMove(Camera.main.transform.forward * velocity);
        }

        //   Vector3 moveDirection = Camera.main.transform.forward;
        //   moveDirection *= velocity * Time.deltaTime;
        //   moveDirection.y = 0.0f;

        ////  if( ButtonExecute.internaltest.a== 1)
        //   transform.position += moveDirection;
    }
}
