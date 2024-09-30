using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonrotate : MonoBehaviour
{
    [SerializeField] private float cannonRotationSpeed = 20f; // Speed of the cannon's rotation



    void Start()
    {

    }

    void Update()
    {


        // Rotate the cannon at a given angle starting from 45 degrees
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * cannonRotationSpeed, 100) - 45);
    }
}
