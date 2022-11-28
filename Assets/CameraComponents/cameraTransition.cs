using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cameraTransition : MonoBehaviour
{
    private float pos = 0;

    [SerializeField]
    private InputAction actionLeft;
    [SerializeField]
    private InputAction actionRight;
    [SerializeField]
    private InputAction actionUp;
    [SerializeField]
    private InputAction actionDown;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        actionLeft.performed += _ => moveCamLeft();
        actionRight.performed += _ => moveCamRight();
        actionUp.performed += _ => moveCamUp();
        actionDown.performed += _ => moveCamDown();
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

    // Update is called once per frame
    void Update()
    {
     
    }

   

    private void OnEnable()
    {
        actionLeft.Enable();
        actionRight.Enable();
        actionUp.Enable();
        actionDown.Enable();
    }

    private void OnDisable()
    {
        actionLeft.Disable();
        actionRight.Disable();
        actionUp.Disable();
        actionDown.Disable();
    }
}
