using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private GameObject _wave;
    [SerializeField] private Vector3 waveOffset = new Vector3(0, -2, 0.75f); 
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        MoveDuck(Input.anyKey);
    }

    void MoveDuck(bool isMoving)
    {
        // Duck が動いた時
        if (isMoving)
        {
            Instantiate(_wave, _transform.position + waveOffset, Quaternion.identity);
            // DuckのUpは+Z
            _transform.Translate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);
            _transform.Translate(Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, 0); 
        }
    }
}
