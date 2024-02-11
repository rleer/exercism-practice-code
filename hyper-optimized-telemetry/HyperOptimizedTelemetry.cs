using System;
using System.Linq;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var prefixAndPaylod = reading switch
        {
            > UInt32.MaxValue => BitConverter.GetBytes(reading).Prepend((byte)(256 - 8)),
            > Int32.MaxValue => BitConverter.GetBytes((uint)reading).Prepend((byte)(4)),
            > UInt16.MaxValue => BitConverter.GetBytes((int)reading).Prepend((byte)(256 - 4)),
            >= UInt16.MinValue => BitConverter.GetBytes((ushort)reading).Prepend((byte)(2)),
            >= Int16.MinValue => BitConverter.GetBytes((short)reading).Prepend((byte)(256 - 2)),
            >= Int32.MinValue => BitConverter.GetBytes((int)reading).Prepend((byte)(256 - 4)),
            < Int32.MinValue => BitConverter.GetBytes(reading).Prepend((byte)(256 - 8)),
        };

        return prefixAndPaylod.Concat(new byte[9 - prefixAndPaylod.Count()]).ToArray();
    }

    public static long FromBuffer(byte[] buffer) => buffer[0] switch
    {
        // long, uint, ushort
        256 - 8 or 4 or 2 => BitConverter.ToInt64(buffer, 1),
        // int
        256 - 4 => BitConverter.ToInt32(buffer, 1),
        // short
        256 - 2 => BitConverter.ToInt16(buffer, 1),
        // invalid prefix byte
        _ => 0,
    };
}
