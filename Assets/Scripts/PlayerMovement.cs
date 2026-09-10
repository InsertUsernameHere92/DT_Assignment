using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float teleportDistance = 5f;
    //[SerializeField] private InputActionReference teleportRef;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public bool teleport = false;
    public int teleportCount = 0;
    private PlayerInputActions playerInputActions;
    public GameObject Player;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Player.Teleport.performed += DoTeleport;
        playerInputActions.Player.Teleport.Enable();
    }

    private void DoTeleport(InputAction.CallbackContext context)
    {
        if (teleport)
        {
            if (teleportCount > 0)
            {
                teleportCount -= 1;
                Debug.Log("TELEPORT TIME!");
                Vector2 playerPos = Player.transform.position;
                Vector2 newPos = playerPos + (moveInput * teleportDistance);
                Player.transform.position = newPos;
            }
        }
    }

    private void OnDisable()
    {
        playerInputActions.Player.Teleport.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    //public void Dash()
    //{
    //    if (teleportRef.action.triggered)
    //    {
    //        if (dash)
    //        {
    //            if (dashCount > 0)
    //            {
    //                dashCount -= 1;
    //                Debug.Log(moveInput);
    //            }
    //        }
    //    }
    //}
}
