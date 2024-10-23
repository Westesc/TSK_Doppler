using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSimulator : MonoBehaviour
{
    public bool simpleSound;
    public float frequency;
    public float sourceFrequency;
    public float volume;
    public AudioSource audioSource;
    public AudioClip clip;
    public int sampleRate = 44100;
    private float oldFrequency=0;
    private bool changetype = false;

    public Toggle toggle;

    private float[] samples;
    private int sampleLength = 44100;

    // Start is called before the first frame update
    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);

    }

    // Update is called once per frame
    void Update()
    {
        if (frequency != oldFrequency|| changetype)
        {
            changetype = false;
            oldFrequency = frequency;
            if (simpleSound)
            {

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
            }
            else
            {
                audioSource.volume = volume;
                audioSource.clip = clip;
                audioSource.pitch = frequency / sourceFrequency;
                audioSource.loop = true;
            }

            audioSource.Play();
        }
    }
    void OnToggleChanged(bool isOn)
    {
        changetype = true;
         simpleSound = isOn;
    }
}
