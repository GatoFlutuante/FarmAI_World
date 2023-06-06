using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controller - Controller")]
    CharacterController controller;
    Vector3 moveDirection;
    public float speed;
    float rotY;
    public float rotationSpeed;

    [Header("Character - Components")]
    public GameObject character;
    Animator animator;
    float angle;
    public FXController fx;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = character.GetComponent<Animator>();
        fx = GetComponent<FXController>();  
    }
    private void Update()
    {
        ControllerMovement();
        CharacterMovement();
        StepsSounds();
    }
    private void ControllerMovement()
    {
        //Movement
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection.y -= 7f;
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * speed * Time.deltaTime);

        //Rotation
        rotY += Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }

    private void StepsSounds()
    {
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            fx.StartStepsSound();
        }
    }

    private void CharacterMovement()
    {
        angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            character.transform.localRotation = Quaternion.Slerp(character.transform.localRotation, rotation, 15 * Time.deltaTime);
        }

        //Animations
        Vector3 movementXY = new Vector3(moveDirection.x, 0, moveDirection.z);
        animator.SetFloat("pMove", movementXY.magnitude);
    }
}
