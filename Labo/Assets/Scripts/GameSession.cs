using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    //State
    float currentScore = 0;
    float killCount = 0;
    float initialTime;

    //Components
    DataManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = GetComponent<DataManager>();
        initialTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(float score)
    {
        currentScore += score;
    }

    public void AddKillCount()
    {
        killCount++;
    }

    public void SaveData()
    {
        float timeAlive = Time.time - initialTime;
        dataManager.SetTotals(currentScore, timeAlive, killCount);
        dataManager.SetHighscore(currentScore);
        dataManager.SetBestTime(timeAlive);
        dataManager.SetMostKills(killCount);
    }
}
