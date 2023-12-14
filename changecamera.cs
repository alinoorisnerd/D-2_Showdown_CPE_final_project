using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class changecamera : MonoBehaviour
{
    public CinemachineVirtualCamera currentCamera;
    // Start is called before the first frame update
    void Start()
    {
        currentCamera.Priority++;
    }

    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        currentCamera.Priority--;

        currentCamera = target;

        currentCamera.Priority++;
    }
}
