using System;
using System.IO;
using UnityEngine;

public class JSONReadWriteSystem : MonoBehaviour
{
    [SerializeField] private int _hits;
    [SerializeField] private int _misses;

    public void SaveToJson()
    {
        ScoreData data = new ScoreData();
        data.HitsScore = _hits.ToString();
        data.MissesScore = _misses.ToString();

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.streamingAssetsPath + "/ScoreData.json", json);
    }

    public void LoadFormJson()
    {
        string json = File.ReadAllText(Application.streamingAssetsPath + "/ScoreData.json");
        ScoreData data = JsonUtility.FromJson<ScoreData>(json);

        _hits = Convert.ToInt32(data.HitsScore);
        _misses = Convert.ToInt32(data.MissesScore);
    }
}
