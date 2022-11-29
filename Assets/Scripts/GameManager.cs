using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] switchCubes;
    public GameObject[] disappearCubes;
    public GameObject[] killCubes;
    
    // Global variables
    static public bool playerAlive;
    static public bool playerWon;

    public void switchCubeStates() {
        foreach (GameObject cube in switchCubes)
        {
            cube.GetComponent<SwitchCube>().switchState();
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
