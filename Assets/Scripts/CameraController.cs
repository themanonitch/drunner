using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [SerializeField] private Transform player;

    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, 0, -10);
    }
}
