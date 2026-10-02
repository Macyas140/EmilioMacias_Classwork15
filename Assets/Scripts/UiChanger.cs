using UnityEngine;
using TMPro;

public class UiChanger : MonoBehaviour
{
    [SerializeField]public TextMeshProUGUI PointsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if(GameManager.Instance != null){
            GameManager.Instance.ChangePoints += NewText;
            NewText(0);
        }
    }

    private void NewText(int newPoints){
        Debug.Log(newPoints);
        if(PointsText != null){
            PointsText.text = " " + newPoints;
        }
    }
}
