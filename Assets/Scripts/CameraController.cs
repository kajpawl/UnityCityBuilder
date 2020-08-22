using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // change size to zoom in/out
    // clamp values to min and max
    // mouse wheel scrolling
    private void LateUpdate()
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * Camera.main.orthographicSize, 2.5f, 20f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
