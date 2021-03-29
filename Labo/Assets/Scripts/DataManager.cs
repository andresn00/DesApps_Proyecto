using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //Keys
    //Records
    string highscoreKey = "highscore";
    string bestTimeKey = "bestTime";
    string mostKillsKey = "mostKills";
    //Total
    string totalScoreKey = "totalScore";
    string totalTimeKey = "totalTime";
    string totalKillsKey = "totalKills";


    private void Start()
    {
        InitializePlayerPrefs();
    }

    //SET RECORDS
    public void SetHighscore(float score)
    {
        if (score > PlayerPrefs.GetFloat(highscoreKey))
        {
            PlayerPrefs.SetFloat(highscoreKey, score);
        }
    }
    public void SetBestTime(float time)
    {
        if (time > PlayerPrefs.GetFloat(bestTimeKey))
        {
            PlayerPrefs.SetFloat(bestTimeKey, time);
        }
    }
    public void SetMostKills(float kills)
    {
        if (kills > PlayerPrefs.GetFloat(mostKillsKey))
        {
            PlayerPrefs.SetFloat(mostKillsKey, kills);
        }
    }

    //SET TOTALS
    public void SetTotals(float score, float time, float kills)
    {
        SetTotalScore(score);
        SetTotalTime(time);
        SetTotalKills(kills);
    }
    public void SetTotalScore(float score)
    {
        float totalScore = PlayerPrefs.GetFloat(totalScoreKey) + score;
        PlayerPrefs.SetFloat(totalScoreKey, totalScore);
    }
    public void SetTotalTime(float time)
    {
        float totalTime = PlayerPrefs.GetFloat(totalTimeKey) + time;
        PlayerPrefs.SetFloat(totalTimeKey, totalTime);
    }
    public void SetTotalKills(float kills)
    {
        float totalKills = PlayerPrefs.GetFloat(totalKillsKey) + kills;
        PlayerPrefs.SetFloat(totalKillsKey, totalKills);
    }

    private void InitializePlayerPrefs()
    {
        //RECORDS
        //Highscore
        if (!PlayerPrefs.HasKey(highscoreKey))
        {
            PlayerPrefs.SetFloat(highscoreKey, 0);
        }
        //Best Time
        if (!PlayerPrefs.HasKey(bestTimeKey))
        {
            PlayerPrefs.SetFloat(bestTimeKey, 0);
        }
        //Most Kills
        if (!PlayerPrefs.HasKey(mostKillsKey))
        {
            PlayerPrefs.SetFloat(mostKillsKey, 0);
        }

        //TOTALS
        //Score
        if (!PlayerPrefs.HasKey(totalScoreKey))
        {
            PlayerPrefs.SetFloat(totalScoreKey, 0);
        }
        //Time
        if (!PlayerPrefs.HasKey(totalTimeKey))
        {
            PlayerPrefs.SetFloat(totalTimeKey, 0);
        }
        //Kills
        if (!PlayerPrefs.HasKey(totalKillsKey))
        {
            PlayerPrefs.SetFloat(totalKillsKey, 0);
        }
    }
}
