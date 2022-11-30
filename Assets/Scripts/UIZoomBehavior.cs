using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UIZoomBehavior : MonoBehaviour
{

    CinemachineBrain brain;

    float orthoSize = 5;
    private bool zoomedIn = true;
    private float speed = 4f;
    // Start is called before the first frame update
    void Awake()
    {
        brain = Camera.main.GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(CinemachineVirtualCameraBase virtCam in ((brain.ActiveVirtualCamera as CinemachineStateDrivenCamera).ChildCameras)) {
              (virtCam as CinemachineVirtualCamera).m_Lens.OrthographicSize = Mathf.MoveTowards((virtCam as CinemachineVirtualCamera).m_Lens.OrthographicSize, orthoSize, speed * Time.deltaTime);   
        } 
    }

    public void zoomInOut()
    {
        if (zoomedIn)
        {
            orthoSize = 10;
            zoomedIn = false;
        }
        else
        {
            orthoSize = 5;
            zoomedIn = true;
        }
    }
}
