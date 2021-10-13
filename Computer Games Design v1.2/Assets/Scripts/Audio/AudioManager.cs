using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGM;

    private void Start()
    {
        BGM = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<AudioManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
    public void ChangeBGM(AudioClip music)
    {
        if (BGM.clip.name == music.name)
        {
            return;
        }
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();

        //FADING AMBIENT AUDIO INTO EACH OTHER - SEE HOW THIS SOUNDS - CURRENTLY NOT WORKING

        //float timeToFade = 1.25f;
        //float timeElapsed = 0;
        //if (newBGM.clip.name == music.name)
        //{
        //    return;
        //}
        //else
        //{
        //    oldBGM.clip = newBGM.clip;
        //    newBGM.clip = music;

        //    newBGM.Play();
        //    while (timeElapsed < timeToFade)
        //    {
        //        newBGM.volume = Mathf.Lerp(0, 1, timeToFade);
        //        oldBGM.volume = Mathf.Lerp(1, 0, timeToFade);
        //        timeElapsed += Time.deltaTime;
        //    }
        //    oldBGM.Stop();
        //}

    }
}
