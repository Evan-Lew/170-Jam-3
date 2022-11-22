using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] switchCubes;

    public void switchCubeStates() {
        foreach (GameObject cube in switchCubes)
        {
            cube.GetComponent<SwitchCube>().switchState();
        }
    }
}
