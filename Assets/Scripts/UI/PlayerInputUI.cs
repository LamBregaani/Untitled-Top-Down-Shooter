using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputUI : MonoBehaviour
{

    //public enum MenuType {Pause, Upgrade, Buildings };

    public int menu;



    public static event Action<GameObject> ActivateBuildUIInput = delegate { };

    public static event Action<GameObject> DeactivateBuildUIInput = delegate { };

    public static event Action<GameObject> ActivateUpgradeUIInput = delegate { };

    public static event Action<GameObject> DeactivateUpgradeUIInput = delegate { };

    public bool buildUIBool;

    public bool upgradeUIBool;

    public int value;

    private bool buildUIActive;

    public void ActivateUI()

    
    {
        if(menu == 1)
        {
            buildUIActive = true;
            ActivateBuildUIInput(this.gameObject);
        }

        else if(menu == 2)
        {
            buildUIActive = true;
            ActivateUpgradeUIInput(this.gameObject);
        }
        
    }

    public void DeactivateUI()
    {
        if(buildUIActive)
        {
            buildUIActive = false;
            DeactivateBuildUIInput(this.gameObject);
            DeactivateUpgradeUIInput(this.gameObject);
        }
        
    }


}
