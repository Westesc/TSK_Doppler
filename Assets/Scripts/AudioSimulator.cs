using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSimulator : MonoBehaviour
{
    public float frequency;
    public float volume;
    public AudioSource audioSource;
    public int sampleRate = 44100;
    private float oldFrequency=0;

    private float[] samples;
    private int sampleLength = 44100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frequency != oldFrequency)
        {
            oldFrequency = frequency;
            samples = new float[sampleLength];
            for (int i = 0; i < samples.Length; i++)
            {
                float time = i / (float)sampleRate;
                samples[i] = volume * Mathf.Sin(2 * Mathf.PI * frequency * time);
            }

            AudioClip clip = AudioClip.Create("RecivedSound", sampleLength, 1, sampleRate, false);
            clip.SetData(samples, 0);

            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
