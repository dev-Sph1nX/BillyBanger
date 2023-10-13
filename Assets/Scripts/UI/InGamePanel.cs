using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : MonoBehaviour
{
    public Slider staminaSlider;
    public TextMeshProUGUI pointsText;

    private float count = 0;

    void Awake()
    {
        GameController.Instance.onScore += this.UpdatePanel;
    }

    public void UpdatePanel(int nbPoints)
    {
        count += nbPoints;
        pointsText.text = count.ToString() + " pts";
    }

    void Update()
    {
        staminaSlider.value = TimeController.instance.stamina;
    }
}
