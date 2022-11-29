using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCube : MonoBehaviour
{
    public GameManager gameManager;
    public bool goal;
    public bool state;   

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        GameManager.playerAlive = true;
        GameManager.playerWon = false;
        switchColor();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (state)
        {
            GameManager.playerAlive = false;
            gameManager.Invoke("resetPlayer", 1f);
        }

        
        if (goal)
        {
            GameManager.playerWon = true;
            gameManager.Invoke("winPlayer", 1f);
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
