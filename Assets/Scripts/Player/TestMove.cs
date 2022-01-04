using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    private CharacterController charController;
    public int moveSpeed;

    float vertInput;
    float horizInput;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {



        if (Input.GetKey("w") && !Input.GetKey("s"))
        {

            vertInput = 10;


        }
        else if (Input.GetKey("s") && !Input.GetKey("w"))
        {
            vertInput = (-0.8f * moveSpeed);
        }
        else
            vertInput = 0;

        if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            horizInput = (0.8f * moveSpeed);
        }
        else if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            horizInput = (-0.8f * moveSpeed);
        }
        else
            horizInput = 0;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;
        charController.SimpleMove(forwardMovement + rightMovement);
    }


}
