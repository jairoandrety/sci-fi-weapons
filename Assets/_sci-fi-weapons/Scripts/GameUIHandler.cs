using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIHandler: UIHandler
{
    [SerializeField] private TextMeshProUGUI textCurrentAmmo;
    [SerializeField] private TextMeshProUGUI textTotalAmmo;

    public void SetAmmo(int currentAmmo, int totalAmmo)
    {
        textCurrentAmmo.text = currentAmmo.ToString();
        textTotalAmmo.text = totalAmmo.ToString();
    }
}
