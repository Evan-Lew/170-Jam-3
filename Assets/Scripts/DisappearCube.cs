using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCube : MonoBehaviour
{
    public bool state;
    public bool goal;
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        GameManager.playerAlive = true;
        GameManager.playerWon = false;
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
}
