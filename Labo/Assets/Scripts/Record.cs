using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Record : MonoBehaviour
{
    [SerializeField] Text[] recordsTexts;

    //KEYS
    //Records
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
        PrintRecords();
    }

    private void PrintRecords()
    {
        float[] dataArr = GetRecords();
        for (int i = 0; i < recordsTexts.Length; i++)
        {
            recordsTexts[i].text = dataArr[i].ToString();
        }
    }

    private float[] GetRecords()
    {
        float score = PlayerPrefs.GetFloat(highscoreKey);
        float time = PlayerPrefs.GetFloat(bestTimeKey);
        float kills = PlayerPrefs.GetFloat(mostKillsKey);
        float totalScore = PlayerPrefs.GetFloat(totalScoreKey);
        float totalTime = PlayerPrefs.GetFloat(totalTimeKey);
        float totalKills = PlayerPrefs.GetFloat(totalKillsKey);

        float[] dataArr = { score, time, kills, totalScore, totalTime, totalKills };
        return dataArr;
    }

    public void DeleteRecords()
    {
        PlayerPrefs.DeleteAll();
    }
}
