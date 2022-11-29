using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCube : MonoBehaviour
{
    public GameManager gameManager;
    public bool goal;
    
    // Disappearing variables
    [SerializeField] private float timeToDisappear = 1f;
    public bool disappearState;
    private bool disappearUpdate = false;
    
    // Time based variables
    private float timer;
    private float disappearCubeTimer;

    void Update()
    {
        timer += Time.deltaTime;
        if (disappearUpdate)
        {
            // Cube will disappear in timeToDisappear once the player collides with it 
            if (timer > disappearCubeTimer + timeToDisappear)
            {
                gameObject.SetActive(false);
            }
        }
    }
    
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        GameManager.playerAlive = true;
        GameManager.playerWon = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (disappearState)
        {
            disappearUpdate = true;
            disappearCubeTimer = timer;
        }
        
        if (goal)
        {
            GameManager.playerWon = true;
            gameManager.Invoke("winPlayer", 1f);
        }
    }
}
