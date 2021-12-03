using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //speed we want char to move
    public float speed = 1;
    //how powerful char can jump
    public float jumpForce = 1;
    //distance to check from the char to the ground
    public float groundCheckDistance = 0.5f;
    //the sprite
    SpriteRenderer sprite = null;
    //rigidbody ref for the physics
    Rigidbody2D rb = null;
    //check if the char is in the air
    bool inAir = false;
    //direction
    float scaleX = 1;
    new Collider2D collider = null;

    // Start is called before the first frame update
    void Start()
    {
        //Set base vars
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        scaleX = transform.localScale.x;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * (Input.GetAxis("Horizontal") * speed) + Vector2.up * rb.velocity.y;

        if (Input.GetAxis("Horizontal") != 0)
        {
            int direction = 1;

            if (Input.GetAxis("Horizontal") < 0)
            {
                direction = -1;
            }

            transform.localScale = new Vector3(scaleX * direction, transform.localScale.y, transform.localScale.z);
        }

        RaycastHit2D[] hit = new RaycastHit2D[1];
        int num = collider.Raycast(Vector2.down, hit, groundCheckDistance);
        Debug.Log(num);
        // If the ray cast hits something, the player is on the ground
        if (num > 0)
        {
            inAir = false;
        }
        else
        {
            // Ray cast doesn't hit anything = player is in the air
            inAir = true;
        }

        // Checks if the player is on the ground and then jumps
        if (!inAir && Input.GetButtonDown("Jump"))
        {
            transform.position += Vector3.up * 0.1f;
            rb.AddForce(Vector2.up * jumpForce);
        }

    }
    void OnDrawGizmos()
    {

        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}

