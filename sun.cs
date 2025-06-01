using UnityEngine;
using System.Collections;

public class sun : MonoBehaviour
{


//    public Vector3 SunSpeed;

//     Use this for initialization
//    void Start()
//    {

//    }

//     Update is called once per frame
//    void Update()
//    {
//         태양 회전
//        transform.Rotate(SunSpeed * Time.deltaTime);
//    }
//}
public float rotationPerSecond = 18.0f;
    private float timer = 0;
    private float settime = 15;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // 태양 회전
        if(timer>settime)
        transform.RotateAround(Vector3.zero,Vector3.right,rotationPerSecond*Time.deltaTime);
    }
}