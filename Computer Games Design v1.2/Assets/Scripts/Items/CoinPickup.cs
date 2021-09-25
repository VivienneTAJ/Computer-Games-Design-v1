using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : Interactable
{
    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            Destroy(gameObject);
            CoinsCollected.coinsCollected++;
            CoinsCollected.coinsText.text = "Coins: " + CoinsCollected.coinsCollected;
        }
    }
}
