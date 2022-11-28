using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchCube : MonoBehaviour
{

    public bool state;
    public bool goal;
    static public bool playerAlive;
    static public bool playerWon;

    void Start()
    {
        playerAlive = true;
        playerWon = false;
        switchColor();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (state)
        {
            playerAlive = false;
            Invoke("resetPlayer", 1f);
        }

        
        if (goal)
        {
            playerWon = true;
            Invoke("winPlayer", 1f);
        }
    }

    // Colliding with red resets the scene
    private void resetPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load next level once goal has been met
    private void winPlayer()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
    
    public void switchState()
    {
        state = !state;
        switchColor();
    }

    private void switchColor()
    {
        if (state)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
