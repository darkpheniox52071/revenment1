using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class MovementScript : MonoBehaviour

{

    public float MoveSpeed = 5.0f;

    public float JumpHeight = 2.0f;

    public float gravity = -9.81f;

    private CharacterController controller;

    private Vector3 velocity;

    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {

        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame

    void Update()

    {

        ConsistentDownwardVelocity();

        MoveCharacter();

        HandleJumping();

    }

    void MoveCharacter()

    {

        float moveX = Input.GetAxis("Horizontal");

        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * MoveSpeed * Time.deltaTime);

    }

    void ConsistentDownwardVelocity()

    {

        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0f)

        {

            velocity.y = -2f;

        }

    }

    void HandleJumping()

    {

        if (Input.GetButtonDown("Jump") && isGrounded)

        {

            velocity.y = Mathf.Sqrt(JumpHeight * -2.0f * gravity);

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

}
