using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioClip bgm;
    private AudioSource m_AudioSource;

    public void StartMusic()
    {
        if (m_AudioSource != null)
        {
            m_AudioSource.PlayOneShot(bgm);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        //StartMusic();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
