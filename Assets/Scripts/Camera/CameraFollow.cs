using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject player;
    public float smoothCamera = 1.5f;
    public Vector3 cameraOffset; // Good Offset: (x: 5.0, y: 3.0, z: -0.3)
  
    void LateUpdate() {
        Vector3 pos = player.transform.position + cameraOffset;
        Vector3 smoothedCamera = Vector3.Lerp(transform.position, pos, smoothCamera * Time.deltaTime);
        transform.position = smoothedCamera;

        transform.LookAt(player.transform);
      }
  }