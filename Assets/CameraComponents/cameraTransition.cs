using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cameraTransition : MonoBehaviour
{
    private float pos = 0;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void moveCamLeft()
    {
        pos += 1;
        if (pos > 3)
        {
            pos = 0;
        }
        animator.SetFloat("Pos", pos);
    }

    public void moveCamRight()
    {
        pos -= 1;
        if (pos < 0)
        {
            pos = 3;
        }
        animator.SetFloat("Pos", pos);
    }

    public void moveCamUp()
    {
        animator.SetBool("IsTopLayer", true);
    }

    public void moveCamDown()
    {
        animator.SetBool("IsTopLayer", false);
    }

}
