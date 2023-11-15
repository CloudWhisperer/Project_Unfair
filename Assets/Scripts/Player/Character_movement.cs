using UnityEngine;

public class Character_movement : MonoBehaviour
{
    private float Horizontal;
    [SerializeField] private float Player_Speed = 8f;
    [SerializeField] private float Jump_Strength = 16f;
    private bool Is_Facing_Right = true;

    [SerializeField] private Rigidbody2D RB2D;
    [SerializeField] private Transform Ground_Check;
    [SerializeField] private LayerMask Ground_Layer;
    [SerializeField] private Animator Player_Animator;

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        //setting animator prameters
        Player_Animator.SetFloat("Speed", Horizontal);
        Player_Animator.SetBool("Is_Grounded", IsGrounded());

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            RB2D.velocity = new Vector2(RB2D.velocity.x, Jump_Strength);
        }

        if (Input.GetButtonUp("Jump") && RB2D.velocity.y > 0f)
        {
            RB2D.velocity = new Vector2(RB2D.velocity.x, RB2D.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        RB2D.velocity = new Vector2(Horizontal * Player_Speed, RB2D.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(Ground_Check.position, 0.2f, Ground_Layer);
    }

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