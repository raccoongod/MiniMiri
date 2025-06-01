using UnityEngine;

public class WASDLookAtMouse : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera mainCamera;

    void Update()
    {
        HandleMovement();
        HandleLook();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }

    void HandleLook()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 lookDir = (hitPoint - transform.position).normalized;
           // lookDir.y = 0f; // 수평 회전만

            if (lookDir != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }
}