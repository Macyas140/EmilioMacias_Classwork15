using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private int collectiblesGoal = 3;

    private int pointss = 0;
    private int collectiblesCollected = 0;
    private bool gameWon = false;

    public event Action<int> ChangePoints;
    public event Action GameWon;

    public int Pointss => pointss;
    public int CollectiblesCollected => collectiblesCollected;
    public int CollectiblesGoal => collectiblesGoal;
    public bool GameWonBool => gameWon;

    private void Awake(){
        if (Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddPoints(int quantity){
        if (gameWon) return;

        pointss += quantity;
        Debug.Log("Puntos: " + pointss);
        collectiblesCollected++;
        Debug.Log("Coleccionables: " + collectiblesCollected + "/" + collectiblesGoal);

        ChangePoints?.Invoke(pointss);

        if (collectiblesCollected >= collectiblesGoal){
            WinGame();
        }
    }

    private void WinGame(){
        if (gameWon) return;
        gameWon = true;
        Debug.Log("¡GANASTE!");
        GameWon?.Invoke();
    }

    public void RestartPoints(){
        pointss = 0;
        collectiblesCollected = 0;
        gameWon = false;
        ChangePoints?.Invoke(pointss);
    }
}