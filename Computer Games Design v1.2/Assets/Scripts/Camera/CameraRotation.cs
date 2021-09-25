using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRotation : MonoBehaviour
{
    public float speed;
    public CinemachineVirtualCamera cam;
    private void Update()
    {

        cam.transform.Rotate(0, speed * Time.deltaTime, 0);

    }

}
