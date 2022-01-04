using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct Stat
{

    public float startValue;

    public float StartValue { get => startValue; set => startValue = value; }

    private float currentValue;

    public float CurrentValue { get => currentValue; set => currentValue = value; }

    private float maxValue;

    public float MaxValue { get => maxValue; set => maxValue = value; }


    public void SetHealthStart()
    {
        CurrentValue = StartValue;
        MaxValue = StartValue;
    }

    
}
