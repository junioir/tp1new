using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontdestroyonloadScene : MonoBehaviour
{

    [SerializeField] private GameObject[] _Objetcts;
    void Awake()
    {
        foreach(var element in _Objetcts)
        {
            DontDestroyOnLoad(element);
        }
    }
}
