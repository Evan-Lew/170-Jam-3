using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCube : MonoBehaviour
{
    private GameManager gameManager;
    
    void Start() 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.keyCubeIncrement();
    }
}
