using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField]
    private GameHud _gameHud;

    public BalanceView BalanceView;

    public void SetLevelText(int level)
    {
        _gameHud.SetLevelText(level);
    }
}