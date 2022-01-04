using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buildText;

    [SerializeField] private GameObject UIPanel;

    private GameObject currentPlatform;




    private void OnEnable()
    {
        BuildUI.ActivateBuildingText += ActivateBuildText;

        BuildUI.DeactivateBuildingText += DeactivateBuildText;

        PlayerInputUI.ActivateBuildUIInput += ActivateBuildUI;

        PlayerInputUI.DeactivateBuildUIInput += DeactivateBuildUI;

        BuildButtonUI.OnButtonPressed += BuildObject;
    }

    private void OnDisable()
    {
        BuildUI.ActivateBuildingText -= ActivateBuildText;

        BuildUI.DeactivateBuildingText -= DeactivateBuildText;

        PlayerInputUI.ActivateBuildUIInput -= ActivateBuildUI;

        PlayerInputUI.DeactivateBuildUIInput -= DeactivateBuildUI;

        BuildButtonUI.OnButtonPressed -= BuildObject;
    }

    private void ActivateBuildText(BuildUI buildPlatorm)
    {
            //buildText.text = "Press ACTION to build";
            currentPlatform = buildPlatorm.gameObject;


    }

    private void DeactivateBuildText(BuildUI buildPlatorm)
    {
        buildText.text = "";
        //currentPlatform = null;
        
    }

    private void ActivateBuildUI(GameObject player)
    {
        //PauseGame.pauseGameInstance.Pause();
        buildText.text = "";
        UIPanel.SetActive(true);
    }

    private void DeactivateBuildUI(GameObject player)
    {
        //PauseGame.pauseGameInstance.Resume();
        //buildText.text = "Press ACTION to build";
        UIPanel.SetActive(false);
    }

    private void BuildObject(GameObject building)
    {
        var buildScript = currentPlatform.GetComponent<BuildObject>();
        buildScript.Build(building);
    }
}
