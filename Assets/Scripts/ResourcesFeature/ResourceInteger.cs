using System;

public class ResourceInteger : IResource<int>
{
    public event Action<int, int> Changed;

    public ResourceType Type { get; }
    public int Amount
    {
        get => _amount;
        set
        {
            var oldValue = _amount;
            _amount = value;

            if (oldValue != _amount)
            {
                Changed?.Invoke(oldValue, _amount);
            }
        }
    }

    private int _amount;

    public ResourceInteger(ResourceType type, int amountByDefault = default)
    {
        Type = type;
        Amount = amountByDefault;
    }
}
