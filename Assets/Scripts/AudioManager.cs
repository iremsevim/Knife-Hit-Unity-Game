using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager live;
    public List<AudioProfil> audios;
    public AudioSource audiosource;
    void Awake()
    {
        live = this;
    }
    public void CreateAudio(string _Audio)
    {

        AudioProfil createaudio = audios.Find(x => x.Audioname == _Audio);
       
        audiosource.PlayOneShot(createaudio.audioclip);
         
    }
    

    [System.Serializable]
    public class AudioProfil
    {
        public string Audioname;
        public AudioClip audioclip;
    }
}
