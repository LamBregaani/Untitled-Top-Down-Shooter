using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUIPool : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void UpdateAmmoUIPool(float _currentAmmo)
    {
        text.text = $"AMMO: {_currentAmmo}";
    }

    public void UpdateAmmoUIClip(float _currentAmmo, float _maxAmmo)
    {
        text.text = $"AMMO: {_currentAmmo}/{_maxAmmo}";
    }
}
