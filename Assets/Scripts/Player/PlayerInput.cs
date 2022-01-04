using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float vertInput;
    public float horizInput;



    private void Update()
    {
        Movement();
    }


    public void Fire()
    {
        print("Fire");
    }



    private void Movement()
    {



        if (Input.GetKey("w") && !Input.GetKey("s"))
        {

            vertInput += 30f * Time.deltaTime;
            vertInput = Mathf.Min(vertInput, 10);


        }
        else if (Input.GetKey("s") && !Input.GetKey("w"))
        {
            vertInput += -30f * Time.deltaTime;
            vertInput = Mathf.Max(vertInput, -8);
        }
        else
            vertInput = 0;

        if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            horizInput += 30f * Time.deltaTime;
            horizInput = Mathf.Max(vertInput, 8);
        }
        else if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            horizInput += -30f * Time.deltaTime;
            horizInput = Mathf.Min(vertInput, -8);
        }
        else
            horizInput = 0;
    }
}
