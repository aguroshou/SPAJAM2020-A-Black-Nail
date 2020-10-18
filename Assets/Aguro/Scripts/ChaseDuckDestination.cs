using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChaseDuckDestination : MonoBehaviour
{
    public Transform target; //追いかける対象-オブジェクトをインスペクタから登録できるように
    public float speed = 0.1f; //移動スピード
    private Vector3 vec;
    private int previewItemCount;
    public AudioClip soundEffectGetItem;
    AudioSource audioSourceGetItem;
    
    void Start()
    {
        audioSourceGetItem = GetComponent<AudioSource>();
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
            transform.position += transform.forward * speed * (float) Time.deltaTime;
        }

        if (GameSystemManager.itemCount != previewItemCount)
        {
            previewItemCount = GameSystemManager.itemCount;
            float duckSize = 0.33333f * (1 + 0.05f * GameSystemManager.itemCount);
            duckSize = System.Math.Min(duckSize, 2f);
            transform.localScale = new Vector3(duckSize,duckSize,duckSize);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Item"))
        {
            audioSourceGetItem.PlayOneShot(soundEffectGetItem);
            GameSystemManager.itemCount++;
            PlayerPrefs.SetInt("ItemCount", GameSystemManager.itemCount);
            Destroy(hit.gameObject);
        }
    }
}