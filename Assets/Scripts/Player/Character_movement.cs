using UnityEngine;

public class Character_movement : MonoBehaviour
{
    private float Horizontal;
    private float Player_Speed = 12f;
    private float Jump_Strength = 26f;
    private bool Is_Facing_Right = true;

    //coyote
    private float coyote_time = 0.05f;
    private float coyote_time_counter;

    //jump buffering
    private float Jump_buffer_time = 0.05f;
    private float Jump_buffer_counter;

    [SerializeField] private Rigidbody2D RB2D;
    [SerializeField] private Transform Ground_Check;
    [SerializeField] private LayerMask Ground_Layer;
    [SerializeField] private Animator Player_Animator;

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        //coyote
        if (IsGrounded())
        {
            coyote_time_counter = coyote_time;
        }
        else
        {
            coyote_time_counter -= Time.deltaTime;
        }

        //jump buffering
        if (Input.GetButtonDown("Jump"))
        {
            Jump_buffer_counter = Jump_buffer_time;
        }
        else
        {
            Jump_buffer_counter -= Time.deltaTime;
        }

        //setting animator prameters
        Player_Animator.SetFloat("Speed", Horizontal);
        Player_Animator.SetBool("Is_Grounded", IsGrounded());

        if (Jump_buffer_counter > 0f && coyote_time_counter > 0f)
        {
            RB2D.velocity = new Vector2(RB2D.velocity.x, Jump_Strength);

            Jump_buffer_counter = 0f;
        }

        if (Input.GetButtonUp("Jump") && RB2D.velocity.y > 0f)
        {
            RB2D.velocity = new Vector2(RB2D.velocity.x, RB2D.velocity.y * 0.5f);

            coyote_time_counter = 0f;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        RB2D.velocity = new Vector2(Horizontal * Player_Speed, RB2D.velocity.y);
    }

    //adds the collision for ground check
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(Ground_Check.position, 0.4f, Ground_Layer);
    }

    //flipping sprite if player is facing left
    private void Flip()
    {
        if (Is_Facing_Right && Horizontal < 0f || !Is_Facing_Right && Horizontal > 0f)
        {
            Is_Facing_Right = !Is_Facing_Right;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}