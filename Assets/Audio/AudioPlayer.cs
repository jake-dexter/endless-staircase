using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    [SerializeField] private float minWaitTime = 5f;
    [SerializeField] private float maxWaitTime = 15f;
    private float currentWaitTime = Mathf.Infinity;

    private AudioClip currentAudioClip;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        currentWaitTime = Random.Range(minWaitTime, maxWaitTime);
    }

    void Update()
    {
        if (!source.isPlaying)
        {
            if (currentWaitTime < 0)
            {
            currentAudioClip = audioClips[Random.Range(0,audioClips.Count)];
            source.clip = currentAudioClip;
            source.Play();
            currentWaitTime = Random.Range(minWaitTime, maxWaitTime);
            }
            else
            {
                currentWaitTime -= Time.deltaTime;
            }
        }
    }
}
