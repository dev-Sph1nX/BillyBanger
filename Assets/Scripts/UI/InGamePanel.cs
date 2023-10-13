using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGamePanel : MonoBehaviour
{
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
}
