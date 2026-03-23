using UnityEditor.ShaderGraph.Internal;

using UnityEngine;

public class Mouselook : MonoBehaviour

{

    public float mouseSensitivity = 600f;

    public Transform playerBody;

    float xRotation = 0f;

    float minimumRotation = -45f;

    float maximumRotation = 45f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;

    }

    // Update is called once per frame

    void Update()

    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, minimumRotation, maximumRotation);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (playerBody != null)

        {

            playerBody.Rotate(Vector3.up * mouseX);

        }

    }

}
 

