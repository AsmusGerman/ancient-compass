using UnityEngine;

// Ensure the component is present on the gameobject the script is attached to
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D body;
    private Vector2 direction;

    void Awake()
    {
        // Setup Rigidbody for frictionless top down movement and dynamic collision
        body = GetComponent<Rigidbody2D>();

        body.isKinematic = false;
        body.angularDrag = 0.0f;
        body.gravityScale = 0.0f;
    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
}