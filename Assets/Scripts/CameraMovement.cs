using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraMovement : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        GameController.Instance.GameOverEvent.AddListener(RemoveCameraFollow);
    }

    private void RemoveCameraFollow()
    {
        vcam.LookAt = null;
        vcam.Follow = null;
    }

}
