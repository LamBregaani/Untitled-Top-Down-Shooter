using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUI : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetSceneByName("UI").isLoaded == false)
        {
            
            SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
            //Debug.Log("UI Loaded");
        }
    }
}
