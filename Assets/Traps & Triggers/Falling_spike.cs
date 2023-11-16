using UnityEngine;

public class Falling_spike : MonoBehaviour
{
    [SerializeField] private GameObject falling_spike;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            falling_spike.SetActive(true);
        }
    }

}
