using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField]
    private Image health_Stats, staminaStats;
         
    public void DisplayHealtStats(float healthValue) {
        healthValue /= 100;

        health_Stats.fillAmount = healthValue;
    }

    public void DisplayStaminaStats(float staminaValue) {

        staminaValue /= 100;

        staminaStats.fillAmount = staminaValue;
    }


}
