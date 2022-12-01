using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int keysCollected = 0;

    public GameObject[] switchCubes;
    public GameObject[] disappearCubes;
    public GameObject[] killCubes;
    public GoalCube goalCube;
    public int neededKeys;
    
    // Global variables
    static public bool playerAlive = true;
    static public bool playerWon = false;

    // Sound effects
    public AudioSource slimeLand;
    public AudioSource slimeDeath;
    public AudioSource goalSfx;
    public AudioSource disappearSfx;

    private void Awake()
    {
        playerWon = false;
        if (keysCollected >= neededKeys)
        {
            goalCube.goal = true;
        }
    }
    
    public void playSlimeLand()
    {
        slimeLand.Play();
    }

    public void playSlimeDeath()
    {
        slimeDeath.Play();
    }

    public void playGoalSfx()
    {
        goalSfx.Play();
    }

    public void playDisappearSfx()
    {
        disappearSfx.Play();
    }
    
    public void switchCubeStates()
    {
        foreach (GameObject cube in switchCubes)
        {
            cube.GetComponent<SwitchCube>().switchState();
        }
    }

    public void keyCubeIncrement()
    {
        keysCollected += 1;
        if (keysCollected >= neededKeys)
        {
            goalCube.goal = true;
        }
    }
    
    // Colliding with red resets the scene
    public void resetPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Load next level once goal has been met
    public void winPlayer()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
