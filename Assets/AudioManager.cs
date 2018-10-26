using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    // Use this for initialization
    void Awake() {

        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds) {


            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.playOnAwake = false;
        }
    }

    // Update is called once per frame
    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) {
            Debug.Log("Wrong sound name: " + name);
        }

        AudioSource.PlayClipAtPoint(s.clip, Camera.main.transform.position, s.volume);
    }
}
