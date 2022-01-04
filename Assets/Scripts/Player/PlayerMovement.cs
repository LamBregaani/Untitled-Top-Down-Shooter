using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _charController;

    [SerializeField]
    private float _moveSpeed;

    private Controls _controls;


    private void Awake()
    {
         _controls = new Controls();

        _controls.Player.Enable();
    }

    private void OnEnable() => _controls.Player.Enable();

    // Start is called before the first frame update
    void Start()
    {
        //_input = GetComponent<PlayerInput>();
        _charController = GetComponent<CharacterController>();
        
        //Debug Remove
        if (_charController == null)
        {
            Debug.Log("No character controller found!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        var movementInput = _controls.Player.Movement.ReadValue<Vector2>();

        var movement = new Vector3
        {
            x = movementInput.x,
            z = movementInput.y
        }.normalized;

        _charController.SimpleMove(movement * _moveSpeed);
    }

    public void SetSpeed(float multiplier)
    {
        _moveSpeed = multiplier;
    }
}
