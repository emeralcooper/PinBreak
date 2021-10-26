using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    [SerializeField] List<Ball> balls;
    [SerializeField] List<Vector3> BallStartingPositions;
    [SerializeField] float newBallDropDelay = 1f;
    [SerializeField] float sceneLoadDelay = 2f;

    private bool gameStarted;
    private int blocksInPlay;

    private void Awake()
    {
        OutOfBounds.OnBallOutOfBounds += StartNewBallInPlay;
        Block.OnBlockDestroyed += DecrementBlocks;
    }

    private void Start()
    {
        PlaceBallsAtStartingPositions();
        blocksInPlay = FindObjectsOfType<Block>().Length;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
            StartGame();
    }

    private void OnDestroy()
    {
        OutOfBounds.OnBallOutOfBounds -= StartNewBallInPlay;
        Block.OnBlockDestroyed -= DecrementBlocks;
    }

    private void StartGame()
    {
        if ((Input.GetMouseButton(0) || Input.GetMouseButton(1)) && !gameStarted)
        {
            balls[0].SetRigidBodyToDynamic();
            gameStarted = true;
        }
    }

    private void PlaceBallsAtStartingPositions()
    {
        for(int i=0; i<balls.Count; i++)
        {
            balls[i].transform.position = BallStartingPositions[i];
        }
    }

    private void StartNewBallInPlay()
    {
        RemoveFirstBallFromBalls();

        if(balls.Count >0)
        {
            balls[0].transform.position = BallStartingPositions[0];
            StartCoroutine(SetRigidBodyToDynamicWithDelay());            
        }
        else
        {
            StartCoroutine(LoadSceneWithDelay(0));
        }
    }

    private IEnumerator SetRigidBodyToDynamicWithDelay()
    {
        yield return new WaitForSeconds(newBallDropDelay);
        balls[0].SetRigidBodyToDynamic();
    }

    private void RemoveFirstBallFromBalls()
    {
        balls.RemoveAt(0);
    }

    private void DecrementBlocks()
    {
        blocksInPlay--;
        if(blocksInPlay <= 0)
        { 
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex+1;
            balls[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            StartCoroutine(LoadSceneWithDelay(nextSceneIndex));
        }
    }

    private IEnumerator LoadSceneWithDelay(int index)
    {        
        yield return new WaitForSeconds(sceneLoadDelay);
        SceneManager.LoadScene(index);
    }
}
