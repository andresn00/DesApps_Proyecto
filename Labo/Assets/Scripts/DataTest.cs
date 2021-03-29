using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataTest : MonoBehaviour
{
    float puntosPorEnemigo = 10;
    [SerializeField] float tiempo = 5;
    [SerializeField] GameSession gameSession;
    float tiempoInicial;
    
    // Start is called before the first frame update
    void Start()
    {
        tiempoInicial = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= tiempoInicial + tiempo)    
        {
            numeroAl();
        } 
           
    }
    void numeroAl()
    {
        float enemigosMuertos = Mathf.Floor(Random.Range(1, 100));
        float puntaje = enemigosMuertos * puntosPorEnemigo;
        gameSession.SaveDataTest(puntaje, tiempo, enemigosMuertos);
        Debug.Log(puntaje+" " + tiempo+" "+ enemigosMuertos+" ");
        SceneManager.LoadScene("Record");
    }
}
