using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    private CapsuleCollider2D capsuleCollider2D;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformsLayerMask;
	public float moveSpeed = 10f; // The speed at which the player moves
	public float jumpVelocity = 50f; // The speed at which the player moves

    private void Awake() {
        rigidBody2D = transform.GetComponent<Rigidbody2D>();
        capsuleCollider2D = transform.GetComponent<CapsuleCollider2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();

        // rigidBody2D.gravityScale = 20;
    }

	// Start is called before the first frame update
	void Start()
    {
        // gameObject.name = "Humpy Dumpty";
    }

    // Update is called once per frame
    void Update()
    {
        // // Get the horizontal and vertical axis inputs
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
		if (IsGrounded() && Input.GetKeyDown(KeyCode.W) == true)
		{
			rigidBody2D.velocity = Vector2.up * jumpVelocity;
		}

        HandleMovement();
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2D.collider != null;
    }

    private void HandleMovement() {
        if(Input.GetKey(KeyCode.A)) {
            rigidBody2D.velocity = new Vector2(-moveSpeed, rigidBody2D.velocity.y);
        } else if (Input.GetKey(KeyCode.D)) {
            rigidBody2D.velocity = new Vector2(+moveSpeed, rigidBody2D.velocity.y);
        } else {
            rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);
        }
    }
}
