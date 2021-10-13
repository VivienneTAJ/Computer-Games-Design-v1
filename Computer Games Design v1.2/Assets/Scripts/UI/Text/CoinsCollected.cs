using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCollected : MonoBehaviour
{
    public static int coinsCollected;
    public static TextMeshProUGUI coinsText;
    private void Awake()
    {
        coinsCollected = 0;
        coinsText = GetComponent<TextMeshProUGUI>();
        coinsText.text = "Coins: " + coinsCollected.ToString();
    }

}
