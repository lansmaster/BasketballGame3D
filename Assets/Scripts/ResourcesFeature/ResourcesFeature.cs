using System;
using System.Collections.Generic;
using System.Linq;

public class ResourcesFeature
{
    private readonly Dictionary<ResourceType, ResourceInteger> _resources;

    public event Action<ResourceType, int, int> ResourceChanged;

    public ResourcesFeature(ResourceInteger[] resources)
    {
        _resources = resources.ToDictionary(r => r.Type);

        foreach (var resource in resources)
        {
            resource.Changed += delegate(int oldValue, int newValue)
            {
                ResourceChanged?.Invoke(resource.Type, oldValue, newValue);
            };
        }
    }

    public void AddResource(ResourceType type, int value)
    {
        var resource = _resources[type];

        resource.Amount += value;
    }

    public void DeleteResource(ResourceType type, int value)
    {
        var resource = _resources[type];

        resource.Amount -= value;
    }

    public bool HasResource(ResourceType type, int value)
    {
        var resource = _resources[type];

        return resource.Amount >= value;
    }

    public string GetResourceValueString(ResourceType type)
    {
        return _resources[type].Amount.ToString();
    }
}
