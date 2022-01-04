using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]public Transform playerPosition;
    [SerializeField]public Vector3 offSet;
    [SerializeField]private float smoothingSpeed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 finalPosition = playerPosition.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, finalPosition, smoothingSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }


}
