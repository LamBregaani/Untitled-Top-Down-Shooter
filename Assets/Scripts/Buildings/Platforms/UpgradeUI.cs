using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public static event Action<UpgradeUI> ActivateUpgradeText = delegate { };

    public static event Action<UpgradeUI> DeactivateUpgradeText = delegate { };

    PlayerInputUI player;


    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerInputUI>();
        if (player != null)
        {
            player.menu = 2;
           
            ActivateUpgradeText(this);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        var tempPlayer = other.GetComponent<PlayerInputUI>();

        if (tempPlayer == player && player != null)
        {
            player.menu = 0;
            ActivateUpgradeText(this);
        }
    }
}
