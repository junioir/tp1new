using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerspawn : MonoBehaviour
{
    

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position ;

        GameObject.FindGameObjectWithTag("MainCamera").transform.position = transform.position;

    }

}
