using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLine : MonoBehaviour {
    float currentAngle = 270f;
    Transform plannetTranform;
    bool spin = false;
    float radius;
    public float x = 0f;
    public float y = 0f;
    public float z = 1f;
    GameController gameController;
    // Use this for initialization
    void Start () {
        gameController = GameObject.FindObjectOfType<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (spin)
        {
            transform.RotateAround(plannetTranform.position, new Vector3(x, y, z), GameDataEditor.speedSpin);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Equals("planet(Clone)"))
        {
            plannetTranform = collision.transform;
            spin = true;
            radius = (collision as CircleCollider2D).radius;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            float newX = plannetTranform.position.x + radius * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            float newY = plannetTranform.position.y + radius * Mathf.Sin(currentAngle * Mathf.Deg2Rad);
            transform.position = new Vector3(newX, newY, transform.position.z);
            gameController.createStateline();
        }

    }
}
