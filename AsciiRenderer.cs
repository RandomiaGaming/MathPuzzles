using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace MathPuzzles
{
    public static class AsciiRenderer
    {
        public static void PrintInDiscord()
        {
            Thread.Sleep(10000);
            foreach(string message in Render(new Bitmap(@"C:\Users\rando\Downloads\Small Butt.png")))
            {
                Clipboard.SetText(message);
                Thread.Sleep(10);
                SendKeys.SendWait("^{V}");
                SendKeys.SendWait("{ENTER}");
                Thread.Sleep(1000);
            }
        }
        public static List<string> Render(Bitmap originalImage)
        {
            List<string> output = new List<string>();
            for (int y = 0; y < originalImage.Height; y++)
            {
                string line = "";
                for (int x = 0; x < originalImage.Width; x++)
                {
                    System.Drawing.Color pixelColor = originalImage.GetPixel(x, y);
                    if (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0 && pixelColor.A == 255)
                    {
                        if (x != 0)
                        {
                            line += " :brown_square:";
                        }
                        else
                        {
                            line += ":brown_square:";
                        }
                    }
                    else if (pixelColor.R == 255 && pixelColor.G == 255 && pixelColor.B == 255 && pixelColor.A == 255)
                    {
                        if (x != 0)
                        {
                            line += " :yellow_square:";
                        }
                        else
                        {
                            line += ":yellow_square:";
                        }
                    }else
                    {
                        if (x != 0)
                        {
                            line += " :black_large_square:";
                        }
                        else
                        {
                            line += ":black_large_square:";
                        }
                    }
                }
                output.Add(line);
            }
            return output;
        }
    }
}
