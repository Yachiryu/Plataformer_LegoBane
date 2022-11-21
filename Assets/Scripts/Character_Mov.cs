using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Character_Mov : MonoBehaviour
{
    public Animator anim;
    
    [Header("Sistema de Movimiento")]
    [Range(0,5)]
    public float movementSpeed;
    public float movementRotate;
    public float runSpeed;

    [Header("Sistema de salto")]
    public float jumpImpulse = 5f;
    public float raycastRange;
    CapsuleCollider capsuleCollider;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        IsRunning(); // Sistema para correr
        
        if (IsGrounded()) // Sistema para atacar
        {
            IsAtacking();
        }

        //Movimiento y rotacion
        Vector3 movementDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        anim.SetFloat("Speed", movementDirection.z);
        transform.Translate((movementDirection * movementSpeed) * Time.deltaTime);
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * movementRotate, 0));

        // Sistema de salto
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpImpulse;
            anim.SetBool("Jump", true);
        }
        if (!IsGrounded()) 
        {
            anim.SetBool("Jump", false);
        }

    }

    bool IsGrounded() 
    {
        return Physics.Raycast(capsuleCollider.transform.position, Vector3.down, raycastRange);
    }

    void IsRunning() 
    {
        Vector3 movementDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate((movementDirection * runSpeed) * Time.deltaTime);
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    void IsAtacking()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("Atk", true);
        }
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("Atk", false);
        }

    }

}
