using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Character_Mov : MonoBehaviour
{
    public Animator anim;

    [Range(0,5)]
    public float movementSpeed;
    public float movementRotate;

    private void Update()
    {
        Vector3 movementDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
        anim.SetFloat("Speed", movementDirection.z);
        transform.Translate((movementDirection * movementSpeed) * Time.deltaTime);
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * movementRotate, 0));
    }
}
