using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    GameObject planet, stateline;
    GameObject[] moonList;
    float[] angleList;


    float distance;
    float radius = 3;
    int angle, numberMoon, currentLevel;


    void Start()
    {
        distance = transform.position.z - Camera.main.transform.position.z;
        radius = Camera.main.ViewportToWorldPoint(new Vector3(0.32407407407f, 0, 0)).x - Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        currentLevel = GameDataEditor.gameData.currentLevel;
        angle = GameDataEditor.gameData.level_data[currentLevel - 1].angle;
        numberMoon = 360 / angle;
        moonList = new GameObject[numberMoon];
        angleList = new float[numberMoon];
        createPlanet();
        createStateline();
        createMoonList();
        updateTextScore();
    }

    void createPlanet()
    {
        planet = Instantiate(Resources.Load("Prefabs/planet")) as GameObject;
        Vector3 vector3 = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.71875f, distance));
        planet.transform.position = vector3;
        planet.GetComponent<CircleCollider2D>().radius = radius;
    }

   public void createStateline()
    {
        stateline = Instantiate(Resources.Load("Prefabs/stateline")) as GameObject;
        Vector3 vector3 = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.2f, distance));
        stateline.transform.position = vector3;
    }

    void createMoonList()
    {
        Vector3 center = planet.transform.position;
        for (int i = 0; i < numberMoon; i++)
        {
            Vector3 pos = RandomCircle(center, radius, angle*(i+1));
            moonList[i] = Instantiate(Resources.Load("Prefabs/moon"), pos, Quaternion.identity) as GameObject;
            angleList[i] = angle;
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius, float angle)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    void updateTextScore()
    {
        GameObject.FindObjectOfType<Text>().text = "0/" + GameDataEditor.gameData.level_data[currentLevel - 1].limit;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < numberMoon; i++)
        {
             moonList[i].transform.RotateAround(planet.transform.position, new Vector3(0f, 0f, 1f), GameDataEditor.speedSpin);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateline.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
        }
       
    }
}
