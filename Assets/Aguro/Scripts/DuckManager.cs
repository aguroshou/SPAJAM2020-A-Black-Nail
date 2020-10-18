using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckManager : MonoBehaviour
{
    public Text text;
    Vector3 cursorPosition;
    Vector3 cursorPosition3d;
    RaycastHit hit;

    [SerializeField] private GameObject duckObject;
    [SerializeField] private GameObject duckDestinationObject;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }
 
    // Update is called once per frame
    void Update()
    {
        Vector2 touchPosition = new Vector2(0.0f, 0.0f);
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            touchPosition = new Vector2(mousePosition.x, mousePosition.y);
        }
        else
        {
            return;
        }
#else
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }
#endif
        //cursorPosition = Input.mousePosition; // 画面上のカーソルの位置
        cursorPosition.x = touchPosition.x;
        cursorPosition.y = touchPosition.y;
        cursorPosition.z = 10.0f; // z座標に適当な値を入れる
        cursorPosition3d = Camera.main.ScreenToWorldPoint(cursorPosition); // 3Dの座標になおす
        
        // カメラから cursorPosition3d の方向へレイを飛ばす
        if (Physics.Raycast(Camera.main.transform.position, (cursorPosition3d - Camera.main.transform.position), out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("WaterRayTarget"))
            {
                duckDestinationObject.transform.position = hit.point;
                    
                Debug.DrawRay(Camera.main.transform.position, (cursorPosition3d - Camera.main.transform.position) * hit.distance, Color.red);
 
                text.text = hit.point.ToString();
            }
        }


    }
}
