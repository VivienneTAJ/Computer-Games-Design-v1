using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Billboard : MonoBehaviour
{
    public GameObject player;

    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
