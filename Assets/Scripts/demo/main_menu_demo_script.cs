using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu_demo_script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        StartCoroutine(returning());
    }

    private IEnumerator returning()
    {
        text.text = "5";
        yield return new WaitForSeconds(1f);

        text.text = "4";
        yield return new WaitForSeconds(1f);

        text.text = "3";
        yield return new WaitForSeconds(1f);

        text.text = "2";
        yield return new WaitForSeconds(1f);

        text.text = "1";
        yield return new WaitForSeconds(1f);

        text.text = "now";
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(0);
    }
}
