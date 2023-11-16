using UnityEngine;

public class Additional_Functions : MonoBehaviour
{
    private Character_movement player_move_script;
    [SerializeField] private Rigidbody2D player_rb2d;
    [SerializeField] BoxCollider2D player_collision;
    [SerializeField] private Animator player_animator;
    [SerializeField] private GameObject death_flash;
    [SerializeField] private Animator cam_anim;

    private void Start()
    {
        player_move_script = GetComponent<Character_movement>();
    }
    public void Player_death()
    {
        //plays the animation, stops movement, stops rigidbody, and does screen flash
        player_animator.SetTrigger("IsDead");
        player_move_script.enabled = false;
        player_collision.enabled = false;
        player_rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        death_flash.SetActive(true);
        cam_anim.SetTrigger("Shake");
    }
}
