using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryController : MonoBehaviour
{
    [SerializeField] private TMP_Text batteryCounter;

    Battery battery;

    private Color fullBattery = new Color(0f, 180f, 0f, 1f);
    private Color halfBattery = new Color(200f, 140f, 0f, 1f);
    private Color noBattery = new Color(200f, 0f, 0f, 1f);

    void Start()
    {
        battery = FindObjectOfType<Battery>();
    }

    void Update()
    {
        ChangeText();
        ChangeColor();
    }

    private void ChangeText()
    {
        batteryCounter.text = "Battery: " + battery.CurrentBattery.ToString();
    }

    private void ChangeColor()
    {
        if (battery.CurrentBattery > 50)
        {
            batteryCounter.color = fullBattery;
        }
        else if (battery.CurrentBattery > 30)
        {
            batteryCounter.color = halfBattery;
        }
        else
        {
            batteryCounter.color = noBattery;
        }
    }
}
