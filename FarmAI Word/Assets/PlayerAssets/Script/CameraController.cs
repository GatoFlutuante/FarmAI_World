using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float rotX;
    public GameObject character;
    public GameObject pai;
    public Transform target;
    Vector3 distanceByCharacter;

    private void Start()
    {
        distanceByCharacter = transform.position - character.transform.position;
    }

    private void Update()
    {
        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, -40, 40);
        Quaternion Rotation = Quaternion.Euler(-rotX, pai.transform.eulerAngles.y, 0);
        transform.position = character.transform.position + Rotation * distanceByCharacter;
        transform.LookAt(target);
    }
}
