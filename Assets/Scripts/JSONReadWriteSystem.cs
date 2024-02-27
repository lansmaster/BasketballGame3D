using System;
using System.IO;
using TMPro;
using UnityEngine;

public class JSONReadWriteSystem : MonoBehaviour
{
    private ResourceInteger[] _resources;
    private ResourcesFeature _resourcesFeature;

    public event Action<ResourcesFeature> ResourcesFeatureLoaded;

    private void Start()
    {
        LoadFormJson();
    }

    private void OnDestroy()
    {
        SaveToJson();
    }

    public void SaveToJson()
    {
        ScoreData data = new ScoreData();
        data.HitsScore = _resourcesFeature.GetResourceValueString(ResourceType.Hit);
        data.MissesScore = _resourcesFeature.GetResourceValueString(ResourceType.Miss);

        string json = JsonUtility.ToJson(data, true);

#if UNITY_EDITOR
        File.WriteAllText(Application.streamingAssetsPath + "/ScoreData.json", json);
#elif UNITY_ANDROID
        File.WriteAllText(Application.persistentDataPath + "/ScoreData.json", json);
#endif
    }

    public void LoadFormJson()
    {
#if UNITY_EDITOR
        string json = File.ReadAllText(Application.streamingAssetsPath + "/ScoreData.json");
#elif UNITY_ANDROID
        if (!File.Exists(Application.persistentDataPath + "/ScoreData.json"))
        {
            WWW reader = new WWW(Application.streamingAssetsPath + "/ScoreData.json");
            while (!reader.isDone) { }

            File.WriteAllBytes(Application.persistentDataPath + "/ScoreData.json", reader.bytes);
        }
        string json = File.ReadAllText(Application.persistentDataPath + "/ScoreData.json");
#endif

        ScoreData data = JsonUtility.FromJson<ScoreData>(json);

        int hits = Convert.ToInt32(data.HitsScore);
        int misses = Convert.ToInt32(data.MissesScore);

        var hit = new ResourceInteger(ResourceType.Hit, hits);
        var miss = new ResourceInteger(ResourceType.Miss, misses);

        _resources = new[] { hit, miss };

        _resourcesFeature = new ResourcesFeature(_resources);

        ResourcesFeatureLoaded?.Invoke(_resourcesFeature);
    }
}
