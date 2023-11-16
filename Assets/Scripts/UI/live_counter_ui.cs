using TMPro;
using UnityEngine;

public class live_counter_ui : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Lives_UI_Text;
    [SerializeField] private GameObject[] life_image;
    private int how_many_off;

    private void Awake()
    {
        life_image = new GameObject[10];

        Lives_UI_Text.SetText(Lives.Player_Lives.ToString());

        switch (Lives.Player_Lives)
        {
            case 9:
                //how_many_off = 1;
                for (int i = Lives.Player_Lives; i < life_image.Length; i++)
                {
                    life_image[i].SetActive(false);
                }
                break;
        }
    }
}
