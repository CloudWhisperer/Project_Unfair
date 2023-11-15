using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class live_counter_ui : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI live_text;

    private void Awake()
    {
        live_text.SetText(Lives.lives.ToString());
    }
}
