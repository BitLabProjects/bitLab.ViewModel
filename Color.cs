using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitLab.ViewModel
{
  public class Color
  {
    public byte R, G, B, A;

    public Color()
    {
      R = G = B = A = 0;
    }

    public Color(byte r, byte g, byte b, byte a = 255)
    {
      R = r;
      G = g;
      B = b;
      A = a;
    }

    public byte GetValue()
    {
      return System.Math.Max(System.Math.Max(R, G), B);
    }

    public Color SetValue(byte value)
    {
      var increment = value - GetValue();
      return AddAll(increment);
    }

    public Color GetOpposite()
    {
      return new Color((byte)(255 - R), 
                       (byte)(255 - G), 
                       (byte)(255 - B));
    }

    public static Color operator ^(Color c1, Color c2)
    {
      return new Color((byte)(c1.R ^ c2.R),
                       (byte)(c1.G ^ c2.G),
                       (byte)(c1.B ^ c2.B));
    }

    public Color AddAll(int value)
    {
      return new Color((byte)System.Math.Max(0, System.Math.Min(255, R + value)),
                       (byte)System.Math.Max(0, System.Math.Min(255, G + value)),
                       (byte)System.Math.Max(0, System.Math.Min(255, B + value)));
    }
  }
}
