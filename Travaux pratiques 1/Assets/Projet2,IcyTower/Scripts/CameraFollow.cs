using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float heightOffset = 2f;

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, player.position.y + heightOffset, transform.position.z);
        transform.position = newPosition;
    }
}
