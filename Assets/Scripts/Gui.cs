using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gui : MonoBehaviour
{
    [SerializeField] Slider Devpoint;
    public TextMeshProUGUI DevText;
    public TextMeshProUGUI CoinsText;
    public PlayerData Data;

    void Start()
    {
        Devpoint.maxValue = Data.MaxDevelopmentPoints;
        Devpoint.value = 0;
    }
    void Update()
    {
        Devpoint.value = Data.DevelopmentPoints;
        DevText.text = Data.DevelopmentPoints.ToString() + "/" + Data.MaxDevelopmentPoints.ToString();
        CoinsText.text = Data.Coins.ToString();
    }
}
