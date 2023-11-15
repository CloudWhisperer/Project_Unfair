using UnityEngine;

public class Additional_Functions : MonoBehaviour
{
    private Character_movement movescript;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] CapsuleCollider2D box;

    //private Animation anim;

    private void Start()
    {
        movescript = GetComponent<Character_movement>();
        //anim = gameObject.GetComponent<Animation>();
    }
    public void Player_death()
    {
        //anim.Play("Death");
        box.enabled = false;
        rb.isKinematic = true;
        movescript.enabled = false;
    }
}
