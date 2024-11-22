using System.Runtime.InteropServices;
using System.Text;

namespace Structs;

[StructLayout(LayoutKind.Explicit)]
struct Color(uint value)
{
    [FieldOffset(3)]
    public byte A;

    [FieldOffset(2)]
    public byte R;

    [FieldOffset(1)]
    public byte G;

    [FieldOffset(0)]
    public byte B;

    [FieldOffset(0)]
    public uint Value = value;

    public static implicit operator Color(uint value) => new(value);
    public static implicit operator uint(Color color) => color.Value;

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Value: 0x{Value:X}");
        builder.AppendLine($"A: {A}");
        builder.AppendLine($"R: {R}");
        builder.AppendLine($"G: {G}");
        builder.AppendLine($"B: {B}");
        return builder.ToString().Trim();
    }
}