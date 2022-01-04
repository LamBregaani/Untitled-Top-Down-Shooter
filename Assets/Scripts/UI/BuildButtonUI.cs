using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButtonUI : MonoBehaviour
{
    [SerializeField] GameObject building;

    public static event Action<GameObject> OnButtonPressed = delegate { };

    
    public void ButtonPressed()
    {
        print("Button Pressed!");
        OnButtonPressed(building);
    }

}
