using System.Collections;
using UnityEngine;

public class PlayerMovement_SideScroll : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    Transform playerTransform;
    RaycastHit2D hit2D;

    public Transform playerHead;
    public Transform playerFeet;

    [SerializeField] float movementSpeed = 1.0f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float playerMass = 1f;
    [SerializeField] float gravity = 9.81f;

    float xVelocity;
    float yVelocity;
    bool isOnGround;
    float horizontalInput;
    bool isJumping;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerRigidbody.gravityScale = gravity;
        playerRigidbody.mass = playerMass;
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Jump") > 0)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        MoveLateral(playerTransform, movementSpeed, horizontalInput);
        CheckForGround();
        Debug.Log(isOnGround);
        if (isOnGround && isJumping)
        {
            Jump(playerRigidbody, jumpForce);
        }
    }

    void MoveLateral(Transform player, float movementSpeed, float xAxisInput)
    {
        xVelocity = xAxisInput * movementSpeed * Time.deltaTime;
        player.Translate(new Vector2(xVelocity, 0), Space.World);
    }

    void Jump(Rigidbody2D player, float jumpForce)
    {
        yVelocity = jumpForce * Time.deltaTime;
        player.AddForce(new Vector2(0, yVelocity), ForceMode2D.Impulse);
        isJumping = false;
    }

    void CheckForGround()
    {
        hit2D = Physics2D.Raycast(playerFeet.position, -playerTransform.up, 0.1f, 3);
        Debug.DrawRay(playerFeet.position, -playerTransform.up, Color.red, 1f, false);
        Debug.Log(hit2D.collider.name.ToString());
        if (hit2D.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }
}
