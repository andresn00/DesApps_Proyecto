using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    //State
    [SerializeField] float currentScore = 0;
    [SerializeField] float killCount = 0;
    float initialTime;

    //Components
    DataManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        dataManager = GetComponent<DataManager>();
        initialTime = Time.time;
    }

    public void AddToScore(float score)
    {
        currentScore += score;
    }

    public void AddKillCount()
    {
        killCount++;
    }

    public void GameOver()
    {
        SaveData();
        SceneManager.LoadScene("Record1");
    }

    private void SaveData()
    {
        float timeAlive = Time.time - initialTime;
        dataManager.SetTotals(currentScore, timeAlive, killCount);
        dataManager.SetHighscore(currentScore);
        dataManager.SetBestTime(timeAlive);
        dataManager.SetMostKills(killCount);
    }
    public void SaveDataTest(float score, float time, float kills)
    {
        dataManager.SetTotals(score, time, kills);
        dataManager.SetHighscore(score);
        dataManager.SetBestTime(time);
        dataManager.SetMostKills(kills);
    }
}
