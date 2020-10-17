using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    public float timeOut = 5.0f;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            // Do anything

            timeElapsed = 0.0f;
            Vector3 prefabPosition = transform.position;
            prefabPosition.x += Random.Range(-0.13f, 0.13f);
            prefabPosition.z += Random.Range(-0.13f, 0.13f);
            GameObject item = Instantiate(itemPrefab, prefabPosition, Quaternion.identity);
            item.transform.SetParent(transform);
        }
    }
}