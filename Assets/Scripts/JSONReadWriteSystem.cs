using System;
using System.IO;
using UnityEngine;

public class JSONReadWriteSystem : MonoBehaviour
{
    //public event Action<int, int> Changed;

    //public int Hits
    //{
    //    get => _hits;
    //    private set
    //    {
    //        var oldValue = _hits;
    //        _hits = value;

    //        if (oldValue != _hits)
    //        {
    //            Changed?.Invoke(oldValue, _hits);
    //        }
    //    }
    //}
    //public int Misses
    //{
    //    get => _misses;
    //    private set
    //    {
    //        var oldValue = _misses;
    //        _misses = value;

    //        if (oldValue != _misses)
    //        {
    //            Changed?.Invoke(oldValue, _misses);
    //        }
    //    }
    //}

    private int _hits;
    private int _misses;

    //private void Awake()
    //{
    //    LoadFormJson();
    //}

    //private void OnDestroy()
    //{
    //    SaveToJson();
    //}

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
