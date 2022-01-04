using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpeed : MonoBehaviour
{
    [System.Serializable]
    public class UpdateSpeedEvent : UnityEvent<float> { }

    [SerializeField] public UpdateSpeedEvent UpdateSpeed;


    [SerializeField] private float baseSpeed;

    [SerializeField] private float currentSpeed;

    private float speedMultiplier;

    private float speedPenalty;


    private void Start()
    {
        SetSpeedBonus(1);
        SetSpeedPenalty(1);
    }

    public void SetSpeedBonus(float mulitiplier)
    {
        speedMultiplier += mulitiplier;

        currentSpeed = baseSpeed * speedMultiplier * speedPenalty;

        UpdateSpeed.Invoke(currentSpeed);
    }

    public void SetSpeedPenalty(float multiplier)
    {
        speedPenalty += multiplier;

        currentSpeed = baseSpeed * speedMultiplier * speedPenalty;

        UpdateSpeed.Invoke(currentSpeed);
    }

}
