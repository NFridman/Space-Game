using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Components")]
    [Tooltip("Main camera transform component")]
    [SerializeField] private Transform m_MainCameraTransform;
    
    [Header("Settings")]
    [Tooltip("Rotation speed")]
    public int speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            var x = -Input.GetAxis("Mouse X") * speed * Time.deltaTime;
            var y = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
            var eulerX = (m_MainCameraTransform.eulerAngles.x + y) % 360;
            var eulerY = (m_MainCameraTransform.rotation.eulerAngles.y + x) % 360;
            m_MainCameraTransform.rotation = Quaternion.Euler(eulerX, eulerY, 0);
        }
    }
}
