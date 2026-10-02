using UnityEngine;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private TextMeshProUGUI VictoryText;

    private string mensaje = "YOU WIN";

    private void Start()
    {
        if (VictoryPanel != null) VictoryPanel.SetActive(false);
        if (VictoryText != null) VictoryText.text = mensaje;

        if (GameManager.Instance != null)
            GameManager.Instance.GameWon += ShowVictory;
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.GameWon -= ShowVictory;
    }

    private void ShowVictory()
    {
        if (VictoryPanel != null)
            VictoryPanel.SetActive(true);
    }
}