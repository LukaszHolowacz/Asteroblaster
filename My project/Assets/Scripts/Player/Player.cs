using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Odczytaj wartoœci ruchu z joysticka
        float horizontalMovement = movementJoystick.joystickVec.x;
        float verticalMovement = movementJoystick.joystickVec.y;

        // Oblicz kierunek ruchu
        Vector2 movementDirection = new Vector2(horizontalMovement, verticalMovement).normalized;

        // Ustaw prêdkoœæ poruszania siê postaci
        rb.velocity = movementDirection * playerSpeed;

        // Obracanie postaci wokó³ w³asnej osi
        if (movementDirection != Vector2.zero)
        {
            float rotationAngle = -Mathf.Atan2(movementDirection.x, movementDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        }
    }
}
