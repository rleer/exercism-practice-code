using System;

class RemoteControlCar
{
    public int Speed { get; }
    public int BatteryDrain { get; }
    private int _battery;
    private int _distanceDriven;
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        Speed = speed;
        BatteryDrain = batteryDrain;
        _battery = 100;
        _distanceDriven = 0;
    }

    public bool BatteryDrained() => _battery <= 0 || BatteryDrain > _battery;
    
    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if (BatteryDrained()) return;
        _battery -= BatteryDrain;
        _distanceDriven += Speed;
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car) => _distance <= (100 / car.BatteryDrain) * car.Speed;
}
