using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoAudioBehavior : MonoBehaviour
{
    public static InfoAudioBehavior Instance;

    [SerializeField] public AudioClip SelectHit;
    


    private AudioSource Source;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;

        Source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        Source.PlayOneShot(clip, volume);
    }

}
