using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour
{
    public AudioClip newTrack;
    private AudioManager audioManager;
    public Animator musicAnim;
    public float waitTime;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (newTrack != null)
        {
            audioManager.ChangeBGM(newTrack);
        }
    }
}
