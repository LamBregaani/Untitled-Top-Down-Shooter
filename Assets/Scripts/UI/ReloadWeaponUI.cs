using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeaponSystem;

public class ReloadWeaponUI : MonoBehaviour
{
    private bool reloading;

    [SerializeField] private Image reloadImage;

    private Coroutine _reloadCo;

    private void OnEnable()
    {
        ReloadWeapon.ReloadingWeapon += ReloadingWeaponUI; 
    }

    private void OnDisable()
    {
        ReloadWeapon.ReloadingWeapon -= ReloadingWeaponUI;
    }

    private void ReloadingWeaponUI(float reloadTime)
    {
        if(!reloading)
        {
            reloading = true;
            if (_reloadCo != null)
                StopCoroutine(_reloadCo);
            _reloadCo = StartCoroutine(Reload(reloadTime));
        }
        
    }

    private IEnumerator Reload(float reloadTime)
    {
        reloadImage.fillAmount = 0;
        reloadImage.gameObject.SetActive(true);
        for (float i = 0; i < reloadTime; i += Time.deltaTime)
        {
            float fillPercentage = i / reloadTime;
            
            reloadImage.fillAmount = fillPercentage;
            yield return new WaitForEndOfFrame();
        }
        reloadImage.fillAmount = 1;
        yield return new WaitForSeconds(0.3f);
        reloadImage.gameObject.SetActive(false);
        reloading = false;
        
    }

}
