using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCollected : MonoBehaviour
{
    public static int coinsCollected = 0;
    public static TextMeshProUGUI coinsText;
    private void Awake()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
        coinsText.text = "Coins: " + coinsCollected.ToString();
    }

}
