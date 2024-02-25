using System;

class WeighingMachine
{
    public int Precision { get; } 
    private double _weight;
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
    public WeighingMachine(int precision) => Precision = precision;
}
