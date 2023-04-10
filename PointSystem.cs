using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PointSystem : MonoBehaviour
{
    public TextMeshProUGUI pointCounter;
    private float point;
    public Camera mainCam;
    public float rotationTime = 2f;
 
    public float randomRotationInterval = 5.0f;

    void Start()
    {
        
        point = 0;
        StartCoroutine(RandomizeRotationCoroutine());

    }

   
    void Update()
    {
        
        pointCounter.text = "Points: " + point;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pointer")
        {
            point++;
        }
    }

    IEnumerator RandomizeRotationCoroutine()
    {
        while (true)
        {
            RandomizeRotation();
            yield return new WaitForSeconds(randomRotationInterval);
        }
    }


    IEnumerator RandomizeRotation()
    {
        Debug.Log("Randomizing rotation"); // Add this line
                                           // Generate a random rotation value
        int randomRotation = UnityEngine.Random.Range(0, 4); // generates a value between 0 and 3

        // Set the rotation based on the random value
        Quaternion targetRotation = Quaternion.Euler(0, 0, randomRotation * 90);

        // Get the starting rotation of the camera
        Quaternion startRotation = mainCam.transform.rotation;

        // Calculate the rotation speed based on the duration of the rotation
        float t = 0.0f;
        float rotationSpeed = 1.0f / rotationTime;

        // Gradually interpolate the camera's rotation towards the target rotation over time
        while (t < 1.0f)
        {
            t += Time.deltaTime * rotationSpeed;
            mainCam.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            yield return null;
        }

    }

}

