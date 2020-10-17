using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private float waveDestroySpeed = 0.3f;
    private void Start()
    {
        Destroy(gameObject, waveDestroySpeed);
    }
}
