using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = .5f;
    public float maxSpeed = 2f;
    public InputAction moveInput;
    
    private Rigidbody2D rigidbody2D;
    private Vector2 moveDirection = new(1, 0);
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        moveInput.Enable();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = moveInput.ReadValue<Vector2>();
        //Debug.Log(move);

        if (!Mathf.Approximately(movement.x, 0.0f) || !Mathf.Approximately(movement.y, 0.0f)) {
            moveDirection.Set(movement.x, movement.y);
            moveDirection.Normalize();
        }

        // animator.SetFloat("Look X", moveDirection.x);
        // animator.SetFloat("Look Y", moveDirection.y);
        //Debug.Log(string.Format("Magnitude: {0}", moveDirection.magnitude));
        // animator.SetFloat("Speed", move.magnitude);
    }

    void FixedUpdate() {
        Vector2 position = (Vector2) rigidbody2D.position + movement * speed * Time.deltaTime;
        rigidbody2D.MovePosition(position);

    }
}
