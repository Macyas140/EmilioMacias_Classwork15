using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
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
    

    public void AddPoints(int quantity){
        if(gameWon) return;

        pointss += quantity;
        Debug.Log(pointss);
        collectiblesCollected++;
        ChangePoints?.Invoke(pointss);
        if(collectiblesCollected >= collectiblesGoal){
            WinGame();
        }
    }

    private void WinGame(){
        if(gameWon) return;
        gameWon = true;
        GameWon?.Invoke();
    }
    
    public void RestartPoints(){
        pointss = 0;
        ChangePoints?.Invoke(pointss);
    }
}
