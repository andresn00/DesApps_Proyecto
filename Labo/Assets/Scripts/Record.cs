using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Record : MonoBehaviour
{
    public Text textoPuntaje;
    public int numPuntaje;
    public Text textoTiempo;
    public int numTiempo;
    public Text textokills;
    public int numkills;
    public Text textoTotalScore;
    public int numTotalScore;
    public Text textoTotalTime;
    public int numTotalTime;
    public Text textoTotalKills;
    public int numTotalKills;


    string highscoreKey = "highscore";
    string bestTimeKey = "bestTime";
    string mostKillsKey = "mostKills";
    //Total
    string totalScoreKey = "totalScore";
    string totalTimeKey = "totalTime";
    string totalKillsKey = "totalKills";

    // Start is called before the first frame update
    void Start()
    {
        GetData();

        numPuntaje = 0;
        numTiempo =0;
        numkills = 0;
        numTotalScore = 0;
        numTotalTime = 0;
        numTotalKills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetData()
    {
        float score = PlayerPrefs.GetFloat(highscoreKey);
         textoPuntaje.text = score.ToString();
        float time = PlayerPrefs.GetFloat(bestTimeKey);
        textoPuntaje.text = time.ToString();
        float kills = PlayerPrefs.GetFloat(mostKillsKey);
        textoPuntaje.text = kills.ToString();
        float totalScore = PlayerPrefs.GetFloat(totalScoreKey);
        textoPuntaje.text = totalScore.ToString();
        float totalTime = PlayerPrefs.GetFloat(totalTimeKey);
        textoPuntaje.text = totalTime.ToString();
        float totalKills = PlayerPrefs.GetFloat(totalKillsKey);
        textoPuntaje.text = totalKills.ToString();

    }
    public void PuntajeAlAzar()
    {
        numPuntaje = Random.Range(0, 1000);
        textoPuntaje.text = numPuntaje.ToString();
    }
}
