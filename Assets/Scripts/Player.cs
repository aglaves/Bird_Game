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
        rigidbody2D.rotation = 45f;
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
    }

    void FixedUpdate() {
        Vector2 currentPosition = (Vector2) rigidbody2D.position;
        Vector2 newPosition = (Vector2) rigidbody2D.position + movement * speed * Time.deltaTime;
        rigidbody2D.MovePosition(newPosition);
        rigidbody2D.MoveRotation(CalculateAngle(currentPosition, newPosition));        
    }

    private float CalculateAngle(Vector2 startPosition, Vector2 endPosition) {
        float rise = endPosition.y - startPosition.y;
        float run = endPosition.x - startPosition.x;
        float angle = Mathf.Atan2(rise, run) * Mathf.Rad2Deg;
        Debug.Log("Rise: " + rise + " Run: " + run + " Calculated angle of movement: " + angle);
        return angle -90;
    }
}
