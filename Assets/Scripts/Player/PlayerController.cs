using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {

}

    

    private void CameraControls()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 lookAtPoint = cameraRay.GetPoint(rayLength);
            Vector3 lookAtPosition = new Vector3(lookAtPoint.x, transform.position.y, lookAtPoint.z);


            float lookATDistanceFromPlayer = Vector3.Distance(lookAtPoint, transform.position);
            if (lookATDistanceFromPlayer > 2)
            transform.LookAt(lookAtPosition);
        }


    }
}
