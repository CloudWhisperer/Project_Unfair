using TMPro;
using UnityEngine;

public class live_counter_ui : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Lives_UI_Text;

    private void Awake()
    {
        Lives_UI_Text.SetText(Lives.Player_Lives.ToString());
    }
}
