using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private BallController _ballController;
    [SerializeField] private HoopChecker _hoopChecker;
    [SerializeField] private TextMeshProUGUI _hitsText;
    [SerializeField] private TextMeshProUGUI _missesText;

    private JSONReadWriteSystem _confInstaller;
    private ResourcesFeature _feature;

    private void Awake()
    {
        _confInstaller = GetComponent<JSONReadWriteSystem>();
        _confInstaller.ResourcesFeatureLoaded += OnResourcesFeatureLoaded;
        _ballController.BallMissed += AddMiss;
        _hoopChecker.BallHitted += AddHit;
    }

    private void OnDestroy()
    {
        _confInstaller.ResourcesFeatureLoaded -= OnResourcesFeatureLoaded;
        _ballController.BallMissed -= AddMiss;
        _hoopChecker.BallHitted -= AddHit;
    }

    private void OnResourcesFeatureLoaded(ResourcesFeature resourcesFeature)
    {
        _feature = resourcesFeature;

        _hitsText.text = _feature.GetResourceValueString(ResourceType.Hit);
        _missesText.text = _feature.GetResourceValueString(ResourceType.Miss);
    }

    private void AddHit()
    {
        _feature.AddResource(ResourceType.Hit, 1);
        _hitsText.text = _feature.GetResourceValueString(ResourceType.Hit);
    }

    private void AddMiss()
    {
        _feature.AddResource(ResourceType.Miss, 1);
        _missesText.text = _feature.GetResourceValueString(ResourceType.Miss);
    }
}
