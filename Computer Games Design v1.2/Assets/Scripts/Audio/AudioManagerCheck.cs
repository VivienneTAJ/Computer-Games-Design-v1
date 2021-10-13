using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerCheck : MonoBehaviour
{
    public GameObject audioManager;
    private void Start()
    {
        if (FindObjectOfType<AudioManager>())
        {
            return;
        }
        else
        {
            Instantiate(audioManager, transform.position, transform.rotation);
        }
    }
}
