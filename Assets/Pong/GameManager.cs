using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text paddleScoreText1;
    [SerializeField] private TMP_Text paddleScoreText2;

    [SerializeField] private Transform paddleTransform1;
    [SerializeField] private Transform paddleTransform2;
    [SerializeField] private Transform ballTransform;

    [SerializeField] private Ball ball;

    public bool gameStarted = false;
    private int paddleScore1;
    private int paddleScore2;

    private static GameManager instance;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }

    public void Paddle1Scored()
    {
        paddleScore1++;
        paddleScoreText1.text = paddleScore1.ToString();
    }
    
    public void Paddle2Scored()
    {
        paddleScore2++;
        paddleScoreText2.text = paddleScore2.ToString();
    }

    public void Restart()
    {
        paddleTransform1.position = new Vector2(paddleTransform1.position.x, 0);
        paddleTransform2.position = new Vector2(paddleTransform2.position.x, 0);
        ballTransform.position = new Vector2(0, 0);
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            gameStarted = true;
            ball.Launch();
        }
    }
}