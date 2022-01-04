using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;

    // Update is called once per frame
    void LateUpdate()
    {
        CameraControls();
    }

    private void CameraControls()
    {


        
        Ray cameraRay = playerCamera.ScreenPointToRay(Mouse.current.position.ReadValue());      //Creates a ray at the current mouse position

        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);        //Creates a plane at 0,0 for the ray to colide with
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 lookAtPoint = cameraRay.GetPoint(rayLength);
            Vector3 lookAtPosition = new Vector3(lookAtPoint.x, transform.position.y, lookAtPoint.z);


            float lookATDistanceFromPlayer = Vector3.Distance(lookAtPoint, transform.position);     //Checks if the ray is within a certain radius of the player. if so, the player rotation is not changed, for smoother look movemnts when near the player
            if (lookATDistanceFromPlayer > 2)
                transform.LookAt(lookAtPosition);
        }

    }
}
