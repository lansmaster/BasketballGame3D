using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ScoreSaveSystem : MonoBehaviour
{
    private static HttpClient httpClient = new HttpClient();

    private ResourceInteger[] _resources;
    private ResourcesFeature _resourcesFeature;

    public event Action<ResourcesFeature> ResourcesFeatureLoaded;

    private void Start()
    {
        InitScore();
    }

    private async void InitScore()
    {
        Steps();

        if (PlayerPrefs.GetString("UserID") != String.Empty)
        {
            await GetRequest();
        }
        else
        {
            SetDefaultScore();
            //
            await PostRequest();
        }
    }

    private async void Steps()
    {
        var task = Task.Run(() => 
        {
            Thread.Sleep(5000);
        });

        AwaitPutRequest();

        await task;

        if (Application.isPlaying)
        {
            Steps();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        AwaitPutRequest();
    }

    private void OnApplicationQuit()
    {
        AwaitPutRequest();
    }

    private async void AwaitPutRequest()
    {
        await PutRequest();

        Debug.Log("Done");
    }

    private async Task PutRequest()
    {
        ScoreData data = new ScoreData();
        data.hits = int.Parse(_resourcesFeature.GetResourceValueString(ResourceType.Hit));
        data.misses = int.Parse(_resourcesFeature.GetResourceValueString(ResourceType.Miss));
        data.id = PlayerPrefs.GetString("UserID");

        var content = new StringContent(JsonUtility.ToJson(data, true), Encoding.UTF8, "application/json");

        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"https://65e5bebfd7f0758a76e73bfd.mockapi.io/user_score/{data.id}");

        request.Content = content;
        
        await httpClient.SendAsync(request);
    }

    private async Task PostRequest()
    {
        ScoreData data = new ScoreData();
        data.hits = int.Parse(_resourcesFeature.GetResourceValueString(ResourceType.Hit));
        data.misses = int.Parse(_resourcesFeature.GetResourceValueString(ResourceType.Miss));

        var content = new StringContent(JsonUtility.ToJson(data, true), Encoding.UTF8, "application/json");

        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"https://65e5bebfd7f0758a76e73bfd.mockapi.io/user_score");

        request.Content = content;

        var response = await httpClient.SendAsync(request);

        string json = await response.Content.ReadAsStringAsync();

        ScoreData responseData = JsonUtility.FromJson<ScoreData>(json);

        PlayerPrefs.SetString("UserID", responseData.id);
    }

    private async Task GetRequest()
    {
        using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://65e5bebfd7f0758a76e73bfd.mockapi.io/user_score/{PlayerPrefs.GetString("UserID")}");

        using HttpResponseMessage response = await httpClient.SendAsync(request);
        if (response.IsSuccessStatusCode) {
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
        else
        {
            Debug.Log("Not internet");
        }
        
    }

    private void SetDefaultScore()
    {
        int hits = 0;
        int misses = 0;

        var hit = new ResourceInteger(ResourceType.Hit, hits);
        var miss = new ResourceInteger(ResourceType.Miss, misses);

        _resources = new[] { hit, miss };

        _resourcesFeature = new ResourcesFeature(_resources);

        ResourcesFeatureLoaded?.Invoke(_resourcesFeature);
    }
}
