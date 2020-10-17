using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallItem : MonoBehaviour
{
    [SerializeField] private GameObject waterPlane;
    
    // Start is called before the first frame update
    void Start()
    {
        waterPlane = GameObject.Find("WaterPlane");
    }

    // Update is called once per frame
    void Update()
    {
        if (waterPlane.transform.position.y < transform.position.y)
        {
            Vector3 position = transform.position;
            position.y -= 0.1f * Time.deltaTime;
            transform.position = position;
        }
        else
        {
            Vector3 position = transform.position;
            position.y = waterPlane.transform.position.y;
            transform.position = position;
        }
    }
}
