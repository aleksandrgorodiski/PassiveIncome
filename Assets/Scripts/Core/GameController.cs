using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameController : Singleton<GameController>
{
    private BalanceController _balanceController; 
    private EffectController _effectController;
    private ConfigController _configController;

    private readonly GameView _gameView;

    public GameController(GameView gameView)
    {
        _gameView = gameView;
        _balanceController = new BalanceController(gameView.BalanceView);
        _configController = new ConfigController();
    }

    public void Start()
    {
        _balanceController.LoadBalance();
        _balanceController.Start();

        //HealthBarView view = Resources.Load<HealthBarView>("blablabla");
        //new HealthbarController(view).DoSomething();
    }

    protected override void OnReleaseResources()
    {
        _balanceController.Dispose();
    }

    void FireEffect(CurrencyConfig _config, int _pieces, Vector3 _effectPosition)
    {
        _effectController.FireEffect(_config, _pieces, _effectPosition + Vector3.up * 3f, null);
    }


    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        Scene _scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(_scene.name);
    }

    public void Update()
    {
        _balanceController.Update();
    }

    internal void StartCoroutine(IEnumerator enumerator)
    {
        _gameView.StartCoroutine(enumerator);
    }
}