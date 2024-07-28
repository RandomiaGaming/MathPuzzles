using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace MathPuzzles
{
    public static class Program
    {
        public static List<ImageFileAverageMap> imageFileAverageMaps = new List<ImageFileAverageMap>();
        [STAThread]
        public static void Main()
        {
            /*double DegToRad = (2 * Math.PI) / 360;

            double t = KinamaticsHelper.ATan2(4.70591859683, -15.495583732);
            double m = KinamaticsHelper.Mag(4.70591859683, -15.495583732);
            Console.WriteLine(t);
            Console.WriteLine(m);*/
            KinamaticsHelper.RunSimulation();
            /*
            double bestGuess = 0;
            double bestGuessAcc = double.PositiveInfinity;

            for (double guess = 198443; guess <= 198443; guess += 1)
            {
                double ret = KinamaticsHelper.RunSimulation(guess);

                double acc = Math.Abs(0.4 - ret);

                if(acc < bestGuessAcc)
                {
                    bestGuess = guess;
                    bestGuessAcc = acc;
                }
            }
            */




            /*long value = 47 * 1024 * 1024;
            long value2 = 1024 * 1024 * 1024;
            long a = 8;
            long b = value * value2 * a;*/
            //Console.WriteLine(b);

            Console.ReadLine();

            /*
            foreach(string bucket in Directory.GetDirectories(@"D:\Media Archive\Photos\Buckets"))
            {
                if(Directory.GetFiles(bucket).Length == 1)
                {
                    File.Move(Directory.GetFiles(bucket)[0], @"D:\Media Archive\Photos\" + Path.GetFileName(Directory.GetFiles(bucket)[0]));
                    Directory.Delete(bucket);
                }
            }
            foreach (string filePath in Directory.GetFiles(@"D:\Media Archive\Photos"))
            {
                imageFileAverageMaps.Add(GetImageFileAverageMap(filePath));
                Console.WriteLine("Got Average Map For: " + filePath);
            }
            int bucketIndex = 0;
            while (imageFileAverageMaps.Count >= 1)
            {
                string currentBucket = @"D:\Media Archive\Photos\Buckets\" + bucketIndex.ToString();
                Directory.CreateDirectory(currentBucket);

                ImageFileAverageMap target = imageFileAverageMaps[0];

                for (int i = 0; i < imageFileAverageMaps.Count; i++)
                {
                    if (BitmapsEqual(target.averageMap, imageFileAverageMaps[i].averageMap))
                    {
                        File.Move(imageFileAverageMaps[i].sourceFilePath, currentBucket + "\\" + Path.GetFileName(imageFileAverageMaps[0].sourceFilePath));
                        imageFileAverageMaps.RemoveAt(i);
                        i--;
                    }
                }

                Console.WriteLine("Finished Bucket: " + bucketIndex + " only " + imageFileAverageMaps.Count + " potential buckets left.");
                bucketIndex++;
            }*/
        }
        public static void InspectDir(string directoryPath)
        {
            if(directoryPath.ToLower() == @"D:\$RECYCLE.BIN".ToLower())
            {
                return;
            }
            foreach (string directory in Directory.GetDirectories(directoryPath))
            {
                InspectDir(directory);
            }
            foreach (string file in Directory.GetFiles(directoryPath))
            {
                if(Path.GetExtension(file).ToLower() != ".cs")
                {
                    break;
                }
                byte[] contents = File.ReadAllBytes(file);
                int totalBytes = contents.Length;
                int lowByteCount = 0;
                for (int i = 0; i < totalBytes; i++)
                {
                    if (contents[i] == 0)
                    {
                        lowByteCount++;
                    }
                }
                if (lowByteCount > (totalBytes / 4))
                {
                    Console.WriteLine(file + " is sus.");
                }
            }
        }
        public static ImageFileAverageMap GetImageFileAverageMap(string filePath)
        {
            Bitmap source = new Bitmap(filePath);
            Bitmap averageMap = new Bitmap(source, new Size(25, 25));
            source.Dispose();
            return new ImageFileAverageMap(filePath, averageMap);
        }
        public static bool BitmapsEqual(Bitmap a, Bitmap b)
        {
            if (a.Width != b.Width || a.Height != b.Height)
            {
                return false;
            }
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    Color aPixelColor = a.GetPixel(x, y);
                    Color bPixelColor = b.GetPixel(x, y);
                    if (Math.Abs(aPixelColor.R - bPixelColor.R) > 25 || Math.Abs(aPixelColor.G - bPixelColor.G) > 25 || Math.Abs(aPixelColor.B - bPixelColor.B) > 25)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public struct ImageFileAverageMap
        {
            public string sourceFilePath;
            public Bitmap averageMap;
            public ImageFileAverageMap(string sourceFilePath, Bitmap averageMap)
            {
                this.sourceFilePath = sourceFilePath;
                this.averageMap = averageMap;
            }
        }
    }
}
