using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public bool followPlayer = true;
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 lastPos = Vector3.zero;


    private void Awake()
    {
        lastPos = transform.position;
    }


    void FixedUpdate()
    {
        if (followPlayer)
        {
            Vector3 desiredPosition = new Vector3(player.position.x ,player.position.y, player.position.z) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
            lastPos = transform.position;
        }
    }
}