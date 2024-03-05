using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class JSONReadWriteSystem : MonoBehaviour
{
    private static HttpClient httpClient = new HttpClient();

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

    private async Task SaveToJson()
    {
        ScoreData data = new ScoreData();
        data.hits = int.Parse(_resourcesFeature.GetResourceValueString(ResourceType.Hit));
        data.misses = int.Parse(_resourcesFeature.GetResourceValueString(ResourceType.Miss));
        data.id = "1";

        var content = new StringContent(JsonUtility.ToJson(data, true), Encoding.UTF8, "application/json");

        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "https://65e5bebfd7f0758a76e73bfd.mockapi.io/user_score/1");

        request.Content = content;
        Debug.Log(content);
        var response = await httpClient.SendAsync(request);
    }

    private async Task LoadFormJson()
    {
        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://65e5bebfd7f0758a76e73bfd.mockapi.io/user_score/1");

        using HttpResponseMessage response = await httpClient.SendAsync(request);

        string content = await response.Content.ReadAsStringAsync();

        ScoreData data = JsonUtility.FromJson<ScoreData>(content);

        int hits = data.hits;
        int misses = data.misses;

        var hit = new ResourceInteger(ResourceType.Hit, hits);
        var miss = new ResourceInteger(ResourceType.Miss, misses);

        _resources = new[] { hit, miss };

        _resourcesFeature = new ResourcesFeature(_resources);

        ResourcesFeatureLoaded?.Invoke(_resourcesFeature);
    }
}
