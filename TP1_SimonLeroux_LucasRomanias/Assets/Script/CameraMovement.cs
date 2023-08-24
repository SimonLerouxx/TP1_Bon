using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{

    public float vitesseLook = 1.5f;
    public float lookXLimit = 45.0f;
    float rotationX;
    float rotationY;
    public float sensitivity = 40;
    float verticalRotation = 0;

    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX = Input.GetAxis("Mouse X") * vitesseLook;
        //rotationY = Input.GetAxis("Mouse Y") * vitesseLook;
        //transform.Rotate(rotationY, rotationX, 0);
        Vector2 delta = Mouse.current.delta.ReadValue() * Time.deltaTime * sensitivity;

        verticalRotation -= delta.y;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);


        Player.transform.Rotate(Vector3.up * rotationX);


        //transform.localRotation = Quaternion.Euler(rotationY, 0, 0);

        

    }

}

   