using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    private GameManager gameManager;
    private bool state = false;

     // Transforms to act as start and end markers for the journey.
    private Vector3 startMarker;
    private Vector3 endMarker;

    // Movement speed in units per second.
    private float speed = 10F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (state)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);
            if (transform.position == endMarker)
            {
                state = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        startTime = Time.time;
        startMarker = transform.position;
        endMarker = transform.position + (gameManager.moveCubeVector * 2);
        journeyLength = Vector3.Distance(startMarker, endMarker);
        state = true;
    }
}
