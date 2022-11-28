using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchCube : MonoBehaviour
{

    public bool state;
    public bool goal;

    void Start()
    {
        switchColor();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Colliding with red resets the scene
        if (state)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Load next level once goal has been met
        if (goal)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
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
