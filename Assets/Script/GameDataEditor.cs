using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;

public class GameDataEditor : MonoBehaviour {

    private string gameDataProjectFilePath = "/Data/gamedata.json";
    public static GameData gameData;
    public static float speedSpin = 50f;

    // Use this for initialization
    void Start () {
        speedSpin = speedSpin * Time.deltaTime;
        string filePath = Application.dataPath + gameDataProjectFilePath;
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            Debug.Log(dataAsJson.ToString());
            gameData = JsonUtility.FromJson<GameData>(dataAsJson);
            Debug.Log(gameData.currentLevel.ToString());
            GameObject.Find("SubTitle").GetComponent<Text>().text = gameData.currentLevel.ToString();
        }
        else
        {

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
