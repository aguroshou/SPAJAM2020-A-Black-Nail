using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChaseDuckDestination : MonoBehaviour
{
    public Transform target; //追いかける対象-オブジェクトをインスペクタから登録できるように
    public float speed = 0.1f; //移動スピード
    private Vector3 vec;

    void Start()
    {
        //target = GameObject.Find("対象").transform; インスペクタから登録するのでいらない
    }

    void Update()
    {
        //targetの方に少しずつ向きが変わる
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.position - transform.position), 0.3f);

        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > 0.01f)
        {
            //targetに向かって進む
            transform.position += transform.forward * speed * (float)Time.deltaTime;
        }
    }
    
    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Item"))
        {
            GameSystemManager.itemCount++;
            PlayerPrefs.SetInt("ItemCount", GameSystemManager.itemCount);
            Destroy(hit.gameObject);
        }
    }
}