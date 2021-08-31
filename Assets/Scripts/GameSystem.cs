using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    [SerializeField] BallGenerator ballGenerator = default;
    bool isDragging;
    [SerializeField] List<Ball> removeBalls = new List<Ball>();
    Ball currentDraggingBall;
    int score;
    [SerializeField] Text scoreText = default;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        AddScore(0);
        StartCoroutine(ballGenerator.Spawns(40));
    }
    void AddScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            //クリック押す
            OnDragBegin();
        }
       else if (Input.GetMouseButtonUp(0))
        {
            //クリック離す
            OnDragEnd();
        }
       else if (isDragging)
        {
            OnDragging();
        }
    }
    void OnDragBegin()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit && hit.collider.GetComponent<Ball>())
        {
            Ball ball = hit.collider.GetComponent<Ball>();
            removeBalls.Add(ball);
            isDragging = true;
        }
    }
    void OnDragging()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit && hit.collider.GetComponent<Ball>())
        {           
            Ball ball = hit.collider.GetComponent<Ball>();
            AddRemoveBall(ball);                      
        }
    }
    void OnDragEnd()
    {
        int removeCount = removeBalls.Count;
        if (removeCount == 2)
        {
            for (int i = 0; i < removeCount; i++)
            {
                Destroy(removeBalls[i].gameObject);
            }
            StartCoroutine(ballGenerator.Spawns(removeCount));
            AddScore(10);
        }
        removeBalls.Clear();
        isDragging = false;
    }
    void AddRemoveBall(Ball ball)
    {
        currentDraggingBall = ball;
        if (removeBalls.Contains(ball) == false)
        {
                removeBalls.Add(ball);
        }
    }
}
