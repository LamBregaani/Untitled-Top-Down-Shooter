using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static PauseGame pauseGameInstance;

    private void Awake()
    {
        if(pauseGameInstance != null)
        {
            pauseGameInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

}
