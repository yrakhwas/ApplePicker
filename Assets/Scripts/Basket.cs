using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    public float speed = 0.1f;  // Швидкість руху
    public float lerpSpeed = 1f;  // Швидкість інтерполяції

    private bool moveLeft = false;
    private bool moveRight = false;
    private Vector3 targetPosition;

    private void Start()
    {
        GameObject gameObject = GameObject.Find("ScoreCounter");
        scoreGT = gameObject.GetComponent<Text>();
        scoreGT.text = "0";
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!moveLeft && !moveRight)
        {
            Vector3 mousePos2D = Input.mousePosition;
            mousePos2D.z = -Camera.main.transform.position.z;
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
            targetPosition.x = mousePos3D.x;
        }

       
        if (moveLeft)
        {
            targetPosition.x = transform.position.x - speed * Time.deltaTime;
        }

        if (moveRight)
        {
            targetPosition.x = transform.position.x + speed * Time.deltaTime;
        }

        
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * lerpSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.tag == "Apple")
        {
            Destroy(gameObject);
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }

    public void OnMoveLeftButtonDown()
    {
        moveLeft = true;
    }

    public void OnMoveLeftButtonUp()
    {
        moveLeft = false;
    }

    public void OnMoveRightButtonDown()
    {
        moveRight = true;
    }

    public void OnMoveRightButtonUp()
    {
        moveRight = false;
    }
}
