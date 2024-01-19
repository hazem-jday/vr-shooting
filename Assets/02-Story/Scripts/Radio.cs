using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Radio : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Call the PlayAudioAfterDelay function after 5 seconds
        Invoke("PlayAudioAfterDelay", 5f);
        audioSource = GetComponent<AudioSource>();
    }


    void PlayAudioAfterDelay()
    {
        // Check if the audio source is not null before playing
        if (audioSource != null)
        {
            // Play the audio
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Audio source is not assigned!");
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(1);
    }

}
