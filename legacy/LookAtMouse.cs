using UnityEngine;

public class CleanMouseLook : MonoBehaviour
{
    public Transform cameraPivot;
    public float sensitivity = 100f;
    public float minPitch = -80f;
    public float maxPitch = 80f;

    float pitch = 0f;
    float yaw = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        transform.localRotation = Quaternion.Euler(0f, yaw, 0f);
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}