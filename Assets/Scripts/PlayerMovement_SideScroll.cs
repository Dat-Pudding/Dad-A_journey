using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_SideScroll : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    Transform playerTransform;

    [SerializeField] float movementSpeed = 1.0f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float playerMass = 70f;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] bool isOnGround;

    Vector2 currentPos;
    Vector2 movementDirection;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        currentPos = playerRigidbody.position;
        playerRigidbody.gravityScale = gravity;
        playerRigidbody.mass = playerMass;
    }

    void Update()
    {
        Debug.DrawLine(currentPos, playerRigidbody.position, Color.red, 1f);

        if (Input.GetAxis("Horizontal") != 0)
        {
            MoveLateral(playerRigidbody, currentPos, movementDirection, movementSpeed);
        }
        if (Input.GetAxis("Jump") != 0)
        {
            Jump(playerRigidbody, currentPos, movementDirection, jumpForce, isOnGround);
        }
    }

    void MoveLateral(Rigidbody2D player, Vector2 currentPos, Vector2 moveDirection, float movementSpeed)
    {
        player.MovePosition(currentPos * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime);
    }

    void Jump(Rigidbody2D player, Vector2 currentPos, Vector2 moveDirection, float jumpForce, bool isOnGround)
    {
        if (isOnGround)
        {
            Debug.Log("Trying to Jump()");
            //currentPos.y += jumpForce * Time.deltaTime;
            //player.AddForce(moveDirection + currentPos, ForceMode2D.Impulse);
            currentPos.y = Mathf.Lerp(currentPos.y, currentPos.y + jumpForce * Time.deltaTime, 1);
        }
    }

    void CheckForGround()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.contactCount == 0)
        {
            isOnGround = false;
        }
    }
}
