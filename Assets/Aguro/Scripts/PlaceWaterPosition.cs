using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceWaterPosition : MonoBehaviour
{
    [SerializeField] private GameObject ArCamera;

    [SerializeField] private GameObject waterObject;
    //ARRaycastManager arRaycastManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool isWaterPlaced = false;

    public void ChangeWaterPlanePosition()
    {
        isWaterPlaced = false;
    }
    
    void Start()
    {
    }

    void Update()
    {
        if (!isWaterPlaced)
        {
            Vector3 setPosition = ArCamera.transform.position;
            setPosition.y -= 0.3f;
            waterObject.transform.position = setPosition;
        }

        // タップした場所に生成
        if (Input.touchCount > 0)
        {
            isWaterPlaced = true;
            
            // if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            // {
            //     Pose hitPose = hits[0].pose;
            //     if (spawnedObj == null)
            //     {
            //         spawnedObj = Instantiate(cubePrefab, hitPose.position, hitPose.rotation);
            //     }
            //     else
            //     {
            //         spawnedObj.transform.position = hitPose.position;
            //     }
            // }
        }
    }
}