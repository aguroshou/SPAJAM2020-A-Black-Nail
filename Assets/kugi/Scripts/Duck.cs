using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // DuckのUpは+Z
        _transform.Translate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);
        _transform.Translate(Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, 0);
    }
}
