using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_death : MonoBehaviour
{
    Additional_Functions playerfunctions;
    private Scene levelscene;
    private int lives;

    private void Start()
    {
        playerfunctions = GameObject.FindGameObjectWithTag("Player").GetComponent<Additional_Functions>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        Lives.lives -= 1;
        playerfunctions.Player_death();
        yield return new WaitForSeconds(1);

        if (Lives.lives != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else
        {
            SceneManager.LoadScene(0);
        }

    }
}
