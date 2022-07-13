using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _winningCondition = 90;
    [SerializeField] private UIController _uiController;
    [SerializeField] private TMPro.TMP_Text _scoreText; 
    private bool _won = false;
    private void Start()
    {
        
    }

    private void Update()
    {
        if(Coin.Count >= _winningCondition)
        {
            _won = true;
        }

        if(_won)
        {
            _uiController.ShowEndGameUI();
            _scoreText.text = "Coins: " + Coin.Count.ToString();
        }
    }

    public void RestartGame()
    {
        Coin.Count = 0;
        _uiController.HideEndGameUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
