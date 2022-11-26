using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    LineRenderer lineRenderer;
    public GameObject compass;
    public GameObject gameManager;
    private float speed = 10f;
    private string state = "Still";
    private Vector3 upVector = new Vector3(0, 0, 1);
    private Vector3 downVector = new Vector3(0, 0, -1);
    private Vector3 rightVector = new Vector3(1, 0, 0);
    private Vector3 leftVector = new Vector3(-1, 0, 0);
    private Vector3 backVector = new Vector3(0, 1, 0);
    private Vector3 left = Vector3.left;
    private Vector3 right = Vector3.right;
    private Vector3 forward = Vector3.forward;
    private Vector3 back = Vector3.back;

    // Update is called once per frame
    void Update()
    {
        if (state == "Still") 
        {
            int layer_mask = LayerMask.GetMask("Compass");
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layer_mask))
            {
                lineRenderer = GameObject.Find("/PlayerCube/Compass/" + hit.collider.name).GetComponent<LineRenderer>();
                lineRenderer.startColor = Color.red;
                lineRenderer.endColor = Color.red;
                if (Input.GetMouseButtonDown(0)) 
                {
                    gameManager.GetComponent<GameManager>().switchCubeStates();
                    state = hit.collider.name.Remove(hit.collider.name.Length - 4);
                    lineRenderer.startColor = Color.white;
                    lineRenderer.endColor = Color.white;
                    compass.SetActive(false);
                }
            }
            else if (lineRenderer)
            {
                lineRenderer.startColor = Color.white;
                lineRenderer.endColor = Color.white;
            }
        }

        if (state == "Up") 
        {
            transform.Translate(upVector * speed * Time.deltaTime);
        }
        else if (state == "Down")
        {
            transform.Translate(downVector * speed * Time.deltaTime);
        }
        else if (state == "Right")
        {
            transform.Translate(rightVector * speed * Time.deltaTime);
        }
        else if (state == "Left")
        {
            transform.Translate(leftVector * speed * Time.deltaTime);
        }
        else if (state == "Back")
        {
            transform.Translate(backVector * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (state)
        {
            case "Up":
                compass.transform.Rotate(-90f, 0f, 0f);
                RotateVectors(left);
                break;
            case "Down":
                compass.transform.Rotate(90f, 0f, 0f);
                RotateVectors(right);
                break;
            case "Right":
                compass.transform.Rotate(0f, 0f, 90f);
                RotateVectors(forward);
                break;
            case "Left":
                compass.transform.Rotate(0f, 0f, -90f);
                RotateVectors(back);
                break;
            case "Back":
                compass.transform.Rotate(0f, 0f, 180f);
                RotateVectors(forward);
                RotateVectors(forward);
                break;
        }
        state = "Still";
        compass.SetActive(true);
        transform.position = new Vector3(MathF.Round(transform.position.x), MathF.Round(transform.position.y), MathF.Round(transform.position.z));
    }
    
    private void RotateVectors(Vector3 axis) {
        upVector = Quaternion.AngleAxis(90, axis) * upVector;
        downVector = Quaternion.AngleAxis(90, axis) * downVector;
        rightVector = Quaternion.AngleAxis(90, axis) * rightVector;
        leftVector = Quaternion.AngleAxis(90, axis) * leftVector;
        backVector = Quaternion.AngleAxis(90, axis) * backVector;
        left = Quaternion.AngleAxis(90, axis) * left;
        right = Quaternion.AngleAxis(90, axis) * right;
        forward = Quaternion.AngleAxis(90, axis) * forward;
        back = Quaternion.AngleAxis(90, axis) * back;
    }
}
