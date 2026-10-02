using UnityEngine;

public class Collectible : MonoBehaviour
{
    private int points = 1;
    private bool collected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other) 
    {
        if(collected){
            return;
        }
        if(other.CompareTag("Player")){
            collected = true;
            if(GameManager.Instance != null){
                GameManager.Instance.AddPoints(points);
            }
            Destroy(gameObject);
        }
        
    }

}
