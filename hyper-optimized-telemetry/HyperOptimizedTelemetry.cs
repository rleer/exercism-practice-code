using System;

public static class TelemetryBuffer
{
    private static (int size, bool isSigned) GetPayloadInfo(long reading)
    {
        switch (reading)
        {
            case > UInt32.MaxValue:
                return (8, true);
            case > Int32.MaxValue:
                return (4, false);
            case > UInt16.MaxValue:
                return (4 , true);
            case >= 0:
                return (2, false);
            case >= Int16.MinValue:
                return (2, true);
            case >= Int32.MinValue:
                return (4, true);
            case < Int32.MinValue:
                return (8, true);
        }
    }
    
    public static byte[] ToBuffer(long reading)
    {
        var buffer = new byte[9];
        var payloadInfo = GetPayloadInfo(reading);
        var payload = BitConverter.GetBytes(reading)[..payloadInfo.size];
        BitConverter.GetBytes(payloadInfo.isSigned ? (256 - payloadInfo.size) : payloadInfo.size).CopyTo(buffer, 0);
        payload.CopyTo(buffer, 1);
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        var prefixByte = buffer[0];
        if (prefixByte is > 8 and < 256 - 8) return 0;
        var isSigned = prefixByte > 8;
        var payloadSize = isSigned ? 256 - prefixByte : prefixByte;
        switch (payloadSize, isSigned)
        { 
            case (8 , _):
                return BitConverter.ToInt64(buffer, 1);
            case (4, false):
                return BitConverter.ToUInt32(buffer[1..(payloadSize + 1)], 0);
            case (4, true):
                return BitConverter.ToInt32(buffer[1..(payloadSize + 1)], 0);
            case (2, false):
                return BitConverter.ToUInt16(buffer[1..(payloadSize + 1)], 0);
            case (2, true):
                return BitConverter.ToInt16(buffer[1..(payloadSize + 1)], 0);
            default:
                return 0;
        }
    }
}
