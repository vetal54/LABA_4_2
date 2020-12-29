using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace LR4Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = Directory.GetFiles(@"C:\Users\user\source\repos\LR4Task2\LR4Task2\Photos");
            string [] names= Directory.GetFiles(@"C:\Users\user\source\repos\LR4Task2\LR4Task2\Photos").Select(Path.GetFileName).ToArray();
            Regex regexExtForImage= new Regex("^((.bmp)|(.gif)|(.tiff?)|(.jpe?g)|(.png))$", RegexOptions.IgnoreCase);
            for (int i=0;i<array1.Length;i++)
            {
                try
                {
                    if (regexExtForImage.IsMatch(Path.GetExtension(array1[i])))
                    {
                        Bitmap bitmap1 = (Bitmap)Bitmap.FromFile(array1[i]);
                        bitmap1.RotateFlip(RotateFlipType.Rotate180FlipY);
                        bitmap1.Save(@"C:\Users\user\source\repos\LR4Task2\LR4Task2\Photos\" + names[i].Split('.')[1] + "-mirrored.png", ImageFormat.Png);
                        Console.WriteLine("Утворено нове фото та збережено");
                    }
                }
                catch (System.OutOfMemoryException)
                {
                    Console.WriteLine("Файл не містить картинки, хоча розширення відповідає");
                }
                 
            }
            Console.ReadKey();
        }
    }
}
