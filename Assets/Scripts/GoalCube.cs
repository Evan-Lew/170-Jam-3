using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCube : MonoBehaviour
{
    public GameManager gameManager;
    public bool goal;
    
    private void OnTriggerEnter(Collider other)
    {
        gameManager.playGoalSfx();
        gameManager.playSlimeLand();
        
        if (goal)
        {
            GameManager.playerWon = true;
            gameManager.Invoke("winPlayer", 1f);
        }
    }
}
