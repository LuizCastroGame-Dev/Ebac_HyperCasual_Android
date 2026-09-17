using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        UpdateUI();
    }

    public void addCoins(int amount = 1)
    {
        coins += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //uiTextCoins.text = coins.ToString();
        //UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }
}
