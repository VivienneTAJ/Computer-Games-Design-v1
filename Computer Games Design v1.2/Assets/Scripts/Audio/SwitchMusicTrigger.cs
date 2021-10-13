using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;
    private AudioManager audioManager;
    public Animator musicAnim;
    public float waitTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (newTrack != null)
            {
                audioManager = FindObjectOfType<AudioManager>();
                audioManager.ChangeBGM(newTrack);
            }
            StartCoroutine(ChangeScene());
        }
    }
    IEnumerator ChangeScene()
    {
        musicAnim.SetTrigger("Fade Out");
        yield return new WaitForSeconds(waitTime);
    }
}
