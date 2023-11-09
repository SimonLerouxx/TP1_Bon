using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{

    public float vitesseLook = 1.5f;
    public float lookXLimit = 45.0f;
    float rotationX;
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

        //Rotation X
        rotationX = Input.GetAxis("Mouse X") * vitesseLook;
        Player.transform.Rotate(Vector3.up * rotationX);


        //Rotation Y
        Vector2 rotation = Mouse.current.delta.ReadValue() * Time.deltaTime * sensitivity;
        verticalRotation = verticalRotation- rotation.y;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        

    }

}

   