using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject soundPlayer;
    [SerializeField] private bool loop;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = soundPlayer.GetComponent<AudioSource>();

        if (loop)
        {
            audioSource.clip = audioClip;
            audioSource.loop = loop;
            audioSource.Play();
        }
    }

    private void OnMouseDown()
    {
        if (!loop)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
