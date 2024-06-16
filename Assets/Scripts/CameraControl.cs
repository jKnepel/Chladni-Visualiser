using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _speed = 0.01f;
    [SerializeField] private float _sensitivity = 1;

	private void LateUpdate()
    {
        // rotation
        if (Input.GetKey(KeyCode.Mouse1))
		{
            Cursor.lockState = CursorLockMode.Locked;
            Quaternion horizontal = Quaternion.AngleAxis(Input.GetAxis("Mouse X") *  _sensitivity, Vector3.up);
            Quaternion vertical = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * _sensitivity, Vector3.right);
            transform.rotation = horizontal * transform.rotation * vertical;
        } 
        else
		{
            Cursor.lockState = CursorLockMode.None;
		}
        
        // x/z movement
        transform.position = transform.position 
            + transform.forward * (Input.GetAxis("Vertical") * _speed)
            + transform.right * (Input.GetAxis("Horizontal") * _speed);

        // y movement
        if (Input.GetKey(KeyCode.Space))
            transform.position += Vector3.up * _speed / 2;
        if (Input.GetKey(KeyCode.LeftShift))
            transform.position -= Vector3.up * _speed / 2;
    }
}
