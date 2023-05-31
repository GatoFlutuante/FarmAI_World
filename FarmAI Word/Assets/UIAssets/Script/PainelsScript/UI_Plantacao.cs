using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Plantacao : MonoBehaviour
{
    public PlantationStatus integrity;
    public Slider waterLevelSlider;
    public Slider lifeLevelSlider;

    private void Update()
    {
        PainelController();
    }

    private void PainelController()
    {
        lifeLevelSlider.value = integrity.pHealth / 100;
        waterLevelSlider.value = integrity.pWater / 100;
    }
}
