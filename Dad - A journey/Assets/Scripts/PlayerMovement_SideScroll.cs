using UnityEngine;

public class PlayerMovement_SideScroll : MonoBehaviour
{
    public Transform playerHead; // Empty child GameObject at the top of the standing sprite
    public Transform playerFeet; // Empty child GameObject at the top of the crouching sprite
    public GameObject playerStanding; // Child GameObject containing the standing sprite
    public GameObject playerCrouching; // Child GameObject containing the crouching sprite

    [SerializeField] float movementSpeed = 1.0f;
    [SerializeField] float jumpForce = 5.0f;
    [SerializeField] float playerMass = 1f;
    [SerializeField] float gravity = 9.81f;

    Rigidbody2D playerRigidbody; // Rigidbody2D attached to the "Player" GameObject
    Transform playerTransform;  // Transform of "Player" container GameObject

    RaycastHit2D headRayHit2D;
    RaycastHit2D footRayHit2D;

    float horizontalInput;
    float xVelocity;
    float yVelocity;
    bool isOnGround;
    bool isJumping;
    bool isCrouching;
    bool isStanding;
    bool canStandUp;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();

        playerRigidbody.gravityScale = gravity;
        playerRigidbody.mass = playerMass;
        isStanding = true;
    }

    void Update() // Checking for Inputs, changing values accordingly
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

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
            isStanding = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
            isStanding = true;
        }
    }

    private void FixedUpdate() // Using Input bools to determine correct behaviour and apply accordingly
    {
        MoveLateral(playerTransform, movementSpeed, horizontalInput);
        CheckForGround(playerTransform, playerFeet);
        CheckForCeiling(playerTransform, playerHead);

        if (isOnGround && isJumping)
        {
            Jump(playerRigidbody, jumpForce);
        }

        if (!isStanding && isCrouching)
        {
            GetCrouched(playerRigidbody);
        }
        if (!isCrouching && canStandUp)
        {
            StandUp(playerRigidbody);
        }
    }

    void MoveLateral(Transform player, float movementSpeed, float xAxisInput) // Takes overloads to perform lateral movement of the player's Transform
    {
        if (isStanding && canStandUp)
        {
            xVelocity = xAxisInput * movementSpeed * Time.deltaTime;
            player.Translate(new Vector2(xVelocity, 0), Space.World);
        }
        else
        {
            xVelocity = xAxisInput * (movementSpeed * 0.5f) * Time.deltaTime;
            player.Translate(new Vector2(xVelocity, 0), Space.World);
        }
    }

    void Jump(Rigidbody2D player, float jumpForce) // Applies an Impulse of value jumpForce to the player's Rigidbody2D
    {
        yVelocity = jumpForce * Time.deltaTime;
        player.AddForce(new Vector2(0, yVelocity), ForceMode2D.Impulse);
        isJumping = false;
    }

    void CheckForGround(Transform pTransform, Transform feet) // Casts Ray2D downwards from "Feet" Transform, sets bool true if hitting collider of tag "Ground"
    {
        footRayHit2D = Physics2D.Raycast(feet.position, -pTransform.up, 0.1f, 3);

        if (footRayHit2D.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
            return;
        }
    }

    void GetCrouched(Rigidbody2D player) // Disables BoxCollider2D and "crouching" GameObject
    {
        if (isCrouching)
        {
            playerStanding.SetActive(false);
            player.GetComponent<BoxCollider2D>().enabled = false;
            playerCrouching.SetActive(true);
        }
    }

    void StandUp(Rigidbody2D player) // Enables BoxCollider2D and "standing" GameObject
    {
        if (canStandUp && isStanding)
        {
            playerStanding.SetActive(true);
            player.GetComponent<BoxCollider2D>().enabled = true;
            playerCrouching.SetActive(false);
        }
    }

    void CheckForCeiling(Transform pTransform, Transform head) // Casts Ray2D upwards from "Head" Transform, sets bool true if hitting any collider except "Player"
    {
        headRayHit2D = Physics2D.Raycast(head.position, pTransform.up, 0.5f, 3);

        if (headRayHit2D.collider == null)
        {
            canStandUp = true;
        }
        else
        {
            canStandUp = false;
        }
    }
}