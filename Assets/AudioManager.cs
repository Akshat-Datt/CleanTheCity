using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake(){
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start(){
        Play("Background");
    }

    public void Play(string name){
        Sounds s = Array.Find(sounds, sound=> sound.name == name);
        s.source.Play();
    }
}
