using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchCube : MonoBehaviour
{

    public bool state;

    void Start()
    {
        switchColor();
    }

    // Colliding with red resets scene
    private void OnTriggerEnter(Collider other)
    {
        if (state)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
