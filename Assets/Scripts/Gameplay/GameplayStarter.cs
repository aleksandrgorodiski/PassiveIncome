using UnityEngine;

public sealed class GameplayStarter : MonoBehaviour
{
    [SerializeField]
    private GameView _gameView;

    private GameController _gameController;

    private void Awake()
    {
        //_gameController = new GameController(_gameView).Start();
        _gameController = new GameController(_gameView);
        _gameController.Start();
    }

    private void OnDestroy()
    {
        _gameController.Dispose();
    }

    private void Update()
    {
        _gameController.Update();
    }
}
