using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Character_Mov : MonoBehaviour
{
    public Animator anim;
    [Range(0,5)]
   
    Rigidbody rb;

    bool jumpFloor;
    bool jumpTrue = false;
    public float jumpForce = 5f;

    public float movementSpeed;
    public float movementRotate;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        Vector3 movementDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        anim.SetFloat("Speed", movementDirection.z);
        transform.Translate((movementDirection * movementSpeed) * Time.deltaTime);
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * movementRotate, 0));

        Vector3 floor = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, floor, 00.5f))
        {
            jumpFloor = true;
        }
        else
        {
            jumpFloor = false;
        }
        jumpTrue = Input.GetButtonDown("Jump");

        if (jumpTrue && jumpFloor)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            anim.SetBool("Saltar", true);
        }
        if (!jumpTrue && jumpFloor)
        {
            anim.SetBool("Saltar", false);
        }
    }
}
