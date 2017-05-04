using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class characterControl : MonoBehaviour
{
    public float movementSpeed, mouseSpeed, rotationUppNer, lasVinkel, acceleration, gravity, jumpHeight, onGround, hopphastighet;

    CharacterController cc;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        cc = GetComponent<CharacterController>();

    }



    // Update is called once per frame
    void Update()
    {
        //Sätter Character kontroll

        //Rotation höger vänster
        float rotationHögerVänster = Input.GetAxis("Mouse X") * mouseSpeed;
        transform.Rotate(0, rotationHögerVänster, 0);

        //Rotation kamera upp och ner
        rotationUppNer -= Input.GetAxis("Mouse Y") * mouseSpeed;
        rotationUppNer = Mathf.Clamp(rotationUppNer, -lasVinkel, lasVinkel);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationUppNer, 0, 0);

        //Vertical & Horizontal flytt
        float speedForward = Input.GetAxis("Vertical") * movementSpeed;
        float speedSideStep = Input.GetAxis("Horizontal") * movementSpeed;
        Vector3 speed = new Vector3(speedSideStep, acceleration, speedForward);

        //Ger en acceleration
        acceleration += Physics.gravity.y * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            acceleration = hopphastighet;
        }
        //Rotation adderad till speed 
        speed = transform.rotation * speed;

        //Implementerar gravityn och spärr för speedhack     
        cc.Move(speed * Time.deltaTime);



        //if (Input.GetKey("space"))
        //{
        //  acceleration = jumpHeight;        
        //}
        //acceleration -= gravity * Time.deltaTime;

    }
}