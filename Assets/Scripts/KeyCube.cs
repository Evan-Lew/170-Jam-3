using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCube : MonoBehaviour
{
    public GoalCube goal;
    public float keys = 0;
    public float neededKeys = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(keys >= neededKeys)
        {
            goal.goal = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        keys += 1;
    }
}
