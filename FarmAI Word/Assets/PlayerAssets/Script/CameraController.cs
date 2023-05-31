using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject pai;
    public GameObject character;
    public Transform target;
    float rotX;

    Vector3 distanceByCharacter;

    private void Start()
    {
        distanceByCharacter = transform.position - character.transform.position;
    }

    private void Update()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, -40, 40);
        Quaternion Rotation = Quaternion.Euler(-rotX, pai.transform.eulerAngles.y, 0);
        transform.position = character.transform.position + Rotation * distanceByCharacter;
        transform.LookAt(target);
    }
}
