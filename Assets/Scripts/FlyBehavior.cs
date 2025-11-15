using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyBehavior : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       bool pressed = false;

        // Klik kiri mouse
        if (Mouse.current?.leftButton.wasPressedThisFrame == true)
            pressed = true;

        // Sentuhan pada layar (Android/iOS)
        if (Touchscreen.current?.primaryTouch.press.wasPressedThisFrame == true)
            pressed = true;

        if (pressed)
            rb.linearVelocity = Vector2.up * flapForce;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }
}
