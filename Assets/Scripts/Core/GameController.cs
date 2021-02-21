using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : GameElement
{
    public BalanceController balanceController;
    public EffectController effectController;


    private void Awake()
    {
        balanceController.LoadBalance();
    }

    private void Start()
    {

    }

    void FireEffect(CurrencyConfig _config, int _pieces, Vector3 _effectPosition)
    {
        effectController.FireEffect(_config, _pieces, _effectPosition + Vector3.up * 3f, null);
    }


    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        Scene _scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(_scene.name);
    }
}