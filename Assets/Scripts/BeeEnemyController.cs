using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BeeEnemyController : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rigidbody2D;
    private float direction = 1f;
    private float switchDirectionTimer = 0f;
    public float switchDirectionTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switchDirectionTimer -= Time.deltaTime;

        if (switchDirectionTimer < 0) {
            direction *= -1;
            switchDirectionTimer = switchDirectionTime;
        }
    }

    void FixedUpdate() {
        Vector2 position = rigidbody2D.position;
        float startX = position.x;
        float startY = position.y;
        position.x = position.x + (speed * direction) * Time.deltaTime;
        rigidbody2D.MovePosition(position);
        rigidbody2D.MoveRotation(CalculateAngle(startX, startY, position.x, position.y));
    }

    private float CalculateAngle(float startPositionX, float startPositionY, float endPositionX, float endPositionY) {
        float rise = endPositionY - startPositionY;
        float run = endPositionX - startPositionX;
        float angle = Mathf.Atan2(rise, run) * Mathf.Rad2Deg;
        Debug.Log("Rise: " + rise + " Run: " + run + " Calculated angle of movement: " + angle);
        return angle -90;
    }
}
