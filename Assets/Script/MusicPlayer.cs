using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	private static MusicPlayer instance = null;

    public AudioClip startClip, gameClip, endClip;

    private AudioSource music;

    public void TurnOffMusic()
    {
        music.Stop();
    }

    public void TurnOnMusic()
    {
        music.loop = true;
        music.Play();
    }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        music = GetComponent<AudioSource>();
        music.clip = startClip;
        music.loop = true;
        music.Play();
    }

    void Start () {
		
	}

    private void OnLevelWasLoaded(int level)
    {
        if(level == 0)
        {
            music.clip = startClip;
        }else if(level == 1)
        {
            music.clip = gameClip;
        }
        else
        {
            music.clip = endClip;
        }
        music.loop = true;
        music.Play();

    }
}
