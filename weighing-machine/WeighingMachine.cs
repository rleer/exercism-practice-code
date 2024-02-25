using System;

class WeighingMachine
{
    private double _weight;
    private double _displayWeight;
    
    public int Precision { get; }
    public double Weight
    {
        get => _weight;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0;

    public string DisplayWeight
    {
        get => $"{(_weight - TareAdjustment).ToString($"F{Precision}")} kg";
    }
    
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
