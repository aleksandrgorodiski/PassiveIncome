using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHud : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _levelText;
    [SerializeField]
    private TextMeshProUGUI _maxLevelText;

    public void SetLevelText(int level)
    {
        _levelText.text = "Level: " +level;
    }
}