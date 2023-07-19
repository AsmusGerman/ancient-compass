using UnityEngine;

// Ensure the component is present on the gameobject the script is attached to
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    
    // Local rigidbody variable to hold a reference to the attached Rigidbody2D component
    private Rigidbody2D body;

    public float limit = 0.7f;
    public float speed = 20.0f;

    void Awake()
    {
        // Setup Rigidbody for frictionless top down movement and dynamic collision
        body = GetComponent<Rigidbody2D>();

        body.isKinematic = false;
        body.angularDrag = 0.0f;
        body.gravityScale = 0.0f;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= limit;
            vertical *= limit;
        }

        body.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}