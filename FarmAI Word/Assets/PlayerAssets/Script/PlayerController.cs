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
    float angle;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        ControllerMovement();
        CharacterMovement();
    }
    private void ControllerMovement()
    {
        //Movement
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * speed * Time.deltaTime);

        //Rotation
        rotY += Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, rotY, 0);
    }
    private void CharacterMovement()
    {
        angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            character.transform.localRotation = Quaternion.Slerp(character.transform.localRotation, rotation, 15 * Time.deltaTime);
        }
    }
}
