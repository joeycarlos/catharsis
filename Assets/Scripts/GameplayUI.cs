﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    // Singleton
    public static GameplayUI Instance { get; private set; }

    public Text healthValue;
    public Text experienceValue;
    public Slider slider;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            // DontDestroyOnLoad(gameObject);  Use if persistence between scenes needed
        } else {
            // Destroy(gameObject);
        }
    }

    public void SetMaxHealth(int value) {
        slider.maxValue = value;
        slider.value = value;
    }

    public void UpdateHealthUI(int value) {
        healthValue.text = value.ToString();
        slider.value = value;
    }

    public void UpdateExpUI(int value) {
        experienceValue.text = value.ToString();
    }
}
