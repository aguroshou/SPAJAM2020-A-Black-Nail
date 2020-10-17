using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameSystemManager : MonoBehaviour
{
    public static int itemCount;

    [SerializeField] private TextMeshProUGUI itemCountText;

    // Start is called before the first frame update
    void Start()
    {
        itemCount = PlayerPrefs.GetInt ("ItemCount", 0);
    }

    // Update is called once per frame
    void Update()
    {
        itemCountText.text = "アイテムの数：" + itemCount;
    }
}
