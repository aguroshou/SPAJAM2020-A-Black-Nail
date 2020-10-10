using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenuSceneButton : MonoBehaviour
{
    static public LoadMenuSceneButton instance;
    void Awake ()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad (gameObject);
        }
        else {
            Destroy (gameObject);
        }
    }
}
