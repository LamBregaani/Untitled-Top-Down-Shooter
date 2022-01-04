using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUI : MonoBehaviour
{
    public static event Action<BuildUI> ActivateBuildingText = delegate { };

    public static event Action<BuildUI> DeactivateBuildingText = delegate { };

    PlayerInputUI player;


    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerInputUI>();
        if(player != null)
        {
            player.menu = 1;
            ActivateBuildingText(this);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        var tempPlayer = other.GetComponent<PlayerInputUI>();

        if(tempPlayer == player && player != null)
        {
            player.menu = 0;
            DeactivateBuildingText(this);
        }
    }
}
