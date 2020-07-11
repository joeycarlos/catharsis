using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int value) {
        slider.maxValue = value;
        slider.value = value;
    }

    public void UpdateHealthUI(int value) {
        slider.value = value;
    }

}
