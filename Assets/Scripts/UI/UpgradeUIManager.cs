using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buildText;

    [SerializeField] private GameObject BuildUIPanel;

    private GameObject currentPlatform;




    private void OnEnable()
    {
        UpgradeUI.ActivateUpgradeText += ActivateText;

        UpgradeUI.DeactivateUpgradeText += DeactivateText;

        PlayerInputUI.ActivateUpgradeUIInput += ActivateUpgradeUI;

        PlayerInputUI.DeactivateUpgradeUIInput += DeactivateUpgradeUI;
    }

    private void OnDisable()
    {
        UpgradeUI.ActivateUpgradeText -= ActivateText;

        UpgradeUI.DeactivateUpgradeText -= DeactivateText;

        PlayerInputUI.ActivateBuildUIInput -= ActivateUpgradeUI;

        PlayerInputUI.DeactivateUpgradeUIInput -= DeactivateUpgradeUI;
    }

    private void ActivateText(UpgradeUI buildPlatorm)
    {
        //buildText.text = "Press ACTION to open upgrade menu";
        currentPlatform = buildPlatorm.gameObject;


    }

    private void DeactivateText(UpgradeUI buildPlatorm)
    {
        buildText.text = "";
        //currentPlatform = null;

    }

    private void ActivateUpgradeUI(GameObject player)
    {
        //PauseGame.pauseGameInstance.Pause();
        buildText.text = "";
        BuildUIPanel.SetActive(true);
    }

    private void DeactivateUpgradeUI(GameObject player)
    {
        //PauseGame.pauseGameInstance.Resume();
        //buildText.text = "Press ACTION to open upgrade menu";
        BuildUIPanel.SetActive(false);
    }
}
