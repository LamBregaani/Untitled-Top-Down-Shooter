using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeSpeed : MonoBehaviour
{

    private PlayerSpeed playerSpeedScript;

    [SerializeField] private float speedMulti;

    private void Awake()
    {
        playerSpeedScript = FindObjectOfType<PlayerSpeed>();
    }

    public void NewSpeed()
    {
        playerSpeedScript.SetSpeedBonus(speedMulti);
    }
}
