using UnityEngine;
using System.Collections;

public class FloorTilt : MonoBehaviour
{
    private float intervalo = 50f;
    private float anguloMaximo = 100f;
    private float duracionTransicion = 1f;
    private Quaternion rotacionInicial;
    private Quaternion rotacionObjetivo;
    private float tiempoTransicion = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start(){
        rotacionInicial = transform.rotation;
        rotacionObjetivo = rotacionInicial;
        StartCoroutine(CicloInclinacion());
        
    }

    // Update is called once per frame
    private void Update(){
        if (tiempoTransicion < duracionTransicion){
            tiempoTransicion += Time.deltaTime;
            float t = Mathf.Clamp01(tiempoTransicion / duracionTransicion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, t);
        }
        
    }
    private IEnumerator CicloInclinacion(){
        while (true){
            yield return new WaitForSeconds(intervalo);
            float anguloX = Random.Range(-anguloMaximo, anguloMaximo);
            float anguloZ = Random.Range(-anguloMaximo, anguloMaximo);
            rotacionObjetivo = rotacionInicial * Quaternion.Euler(anguloX, 0f, anguloZ);
        }
    }
}
