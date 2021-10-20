using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    public float scrollSpeed;
    public float minZoomSize, maxZoomSize;
    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
    public void ZoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            if (cam.orthographicSize < minZoomSize)
            {
                cam.orthographicSize = minZoomSize;
            }
            if (cam.orthographicSize > maxZoomSize)
            {
                cam.orthographicSize = maxZoomSize;
            }         
        }
    }
}
