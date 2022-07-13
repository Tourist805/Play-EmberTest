using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _scoreText;
    [SerializeField] private GameObject _endGameScreen;
    private void Update()
    {
        _scoreText.text = "Coins: " + Coin.Count.ToString();
    }

    public void ShowEndGameUI()
    {
        _endGameScreen.SetActive(true);
    }

    public void HideEndGameUI()
    {
        _endGameScreen.SetActive(false);
    }
}
