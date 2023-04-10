using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WallSpawner : MonoBehaviour
{
    public GameObject[] wallPrefabs;  // Spawn edilecek duvar prefablari
                                      // Duvarlarýn spawn edileceði nokta
    public float wallHeightY;

    public float wallSpawnInterval;
    public float wallSpeed;

    private float lastWallSpawnTime;
    private float screenHalfWidth;
    private bool isPlayerAlive = true;

    private void Start()
    {
       
            screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;       
    }

    

    private void Update()
    {
        Invoke("RestartGame", 1f);
        CanSpawnWall();
        if (Time.time > lastWallSpawnTime + wallSpawnInterval)
        {
            SpawnWall();
            lastWallSpawnTime = Time.time;
        }

        foreach (Transform child in transform)
        {
            child.position += Vector3.left * wallSpeed * Time.deltaTime;

            if (child.position.x < -screenHalfWidth - 3f)
            {
                Destroy(child.gameObject);
            }
        }
    }

    void CanSpawnWall()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            isPlayerAlive = false;
        }

    }
    void SpawnWall()
    {
        if (isPlayerAlive)
        {
            int randomWallIndex = Random.Range(0, wallPrefabs.Length);
            GameObject newWall = Instantiate(wallPrefabs[randomWallIndex], transform);
            newWall.transform.position = new Vector2(screenHalfWidth + 1, wallHeightY);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }

    private void RestartGame()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            SceneManager.LoadScene(0);
        }

    }
}

//4 3 2-alt
