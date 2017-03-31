﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoreGame : MonoBehaviour {

    private Button button;

	// Use this for initialization
	void Start () {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(GoToWeb);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //https://forum.unity3d.com/threads/how-to-open-an-market-intent.63931/
    void GoToWeb()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("Android");
        }else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Debug.Log("Ios");
        }
        Application.OpenURL("market://details?id=com.Ibnesina.ImpossibleRushGame");
    }
}
