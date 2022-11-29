using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCube : MonoBehaviour
{
    public GameManager gameManager;
    public bool killState;   

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        GameManager.playerAlive = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        gameManager.playSlimeJump();
        
        if (killState)
        {
            GameManager.playerAlive = false;
            gameManager.Invoke("resetPlayer", 1f);
        }
    }
}
