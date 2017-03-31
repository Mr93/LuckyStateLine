using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {

    private bool soundOn = true;
    private MusicPlayer musicPlayer;
    private Text text;
    private string defaultText = "Sound is";

    // Use this for initialization
    void Start () {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>().GetComponent<MusicPlayer>();
        text = (GameObject.Find("SoundButton")).GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonSoundClicked()
    {
        if (soundOn)
        {
            musicPlayer.TurnOffMusic();
            text.text = defaultText + " Off";
        }
        else
        {
            musicPlayer.TurnOnMusic();
            text.text = defaultText + " On";
        }
        soundOn = !soundOn;
    }
}
