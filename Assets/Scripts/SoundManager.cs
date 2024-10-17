using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)] public float volume = 1f;
    [Range(.1f, 3f)] public float pitch = 1f;

    [HideInInspector] public AudioSource source;

    public bool loop;
}

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        var s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void Play3d(string name, Vector3 cords, float volume)
    {
        var s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        AudioSource.PlayClipAtPoint(s.clip, cords, volume);
    }

    public void Stop(string name)
    {
        var s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }
    
    public void MuteSFX()
    {
        foreach (var s in sounds)
        {
            if (!s.source.loop) 
            {
                s.source.mute = !s.source.mute;
            }
        }
    }

    public void MuteMusic()
    {
        foreach (var s in sounds)
        {
            if (s.source.loop)
            {
                s.source.mute = !s.source.mute;
            }
        }
    }
}
