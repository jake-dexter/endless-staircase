using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    [SerializeField] List<AudioSource> allAudioSources = new List<AudioSource>(); 
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioSource source;
    [SerializeField] Canvas gameOverCanvas;

    private void Start()
    {
        gameOverCanvas.enabled = false;    
    }

    public void ProccessDeath()
    {
        foreach (AudioSource oldSource in allAudioSources)
        {
            oldSource.Stop();
        }

        source.clip = deathSound;
        source.Play();

        gameOverCanvas.enabled = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
