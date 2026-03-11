using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 100;
    public float gravity = -9.8f;
    public Transform cameraTransform;
    public float sensivity = 0.5f;
    public float minLimit = -80f;
    public float maxLimit = 80f;

    private PlayerInputAction _inputAction;
    private CharacterController _characterController;

    private Vector2 _movement;
    private Vector3 _velocity;
    private Vector2 _look;

    private float _currentRotationY;

    private void Awake()
    {
        _inputAction = new PlayerInputAction();
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _inputAction.Player.Enable();
        _inputAction.Player.Move.performed += SetMovement;
        _inputAction.Player.Move.canceled += ctx => _movement = Vector2.zero;
        _inputAction.Player.Look.performed += SetLook;
        _inputAction.Player.Look.canceled += ctx => _look = Vector2.zero;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetLook(InputAction.CallbackContext ctx)
    {
        _look = ctx.ReadValue<Vector2>();
    }

    private void SetMovement(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>();     
    }

    private void Movement()
    {
        float velocidadFija = 300f;
        Vector3 move = (transform.right * _movement.x + transform.forward * _movement.y) * velocidadFija;        
        _characterController.Move(move * Time.deltaTime);
        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void Look()
    {
        Vector2 mouseNormalized = _look * sensivity;
        _currentRotationY = Mathf.Clamp(_currentRotationY - mouseNormalized.y, minLimit, maxLimit);
        cameraTransform.localRotation = Quaternion.Euler(_currentRotationY, 0, 0);
        transform.Rotate(Vector3.up * mouseNormalized.x);
    }

    private void Update()
    {
        Movement();
        Look();
    }
}