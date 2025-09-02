using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] private float maxBattery = 100f;
    [SerializeField] private float drainRate = 5f;

    private float currentBattery;
    public float CurrentBattery { get { return (int)currentBattery; } }

    private bool outOfBattery;
    public bool OutOfBattery { get { return outOfBattery; } }

    void Start()
    {
        RechargeBattery();
    }

    public void RechargeBattery()
    {
        currentBattery = maxBattery;
        outOfBattery = false;
    }

    public void DrainBattery()
    {
        if (currentBattery > 0)
        {
            currentBattery -= drainRate * Time.deltaTime;
        }
        else
        {
            outOfBattery = true;
        }
    }
}
