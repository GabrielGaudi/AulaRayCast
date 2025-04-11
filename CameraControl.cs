using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float lookSpeed = 5f;
    float cameraVertical;
    public Transform PlayerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        cameraVertical -= mouseY;
        cameraVertical = Mathf.Clamp(cameraVertical, -90, 90);

        transform.localRotation = Quaternion.Euler(cameraVertical, 0, 0);
        PlayerTransform.Rotate(Vector3.up * mouseX);
    }
}
