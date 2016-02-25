using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitLab.ViewModel
{
  public class Colors
  {
    private Colors()
    {
    }

    public static readonly Color Black = new Color(  0,   0,   0);
    public static readonly Color White = new Color(255, 255, 255);
    public static readonly Color Red   = new Color(255,   0,   0);
    public static readonly Color SteelBlue     = new Color(160, 180, 240);
    public static readonly Color DarkSteelBlue = new Color( 65, 105, 225);
    public static readonly Color Orange        = new Color(255, 127,  39);
    public static readonly Color Salmon        = new Color(255, 155,  90);
  }
}
