using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or 좌/우 방향키
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S or 상/하 방향키

        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized;

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}