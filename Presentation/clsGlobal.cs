using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public class clsGlobal
    {
        public static Bitmap LoadImage(string imagePath)
        {
            if  (string.IsNullOrWhiteSpace(imagePath)|| !File.Exists(imagePath))
            {
                return null;
            }

          
            // Load bytes -> create a copy in memory -> file is NOT locked
            byte[] bytes = File.ReadAllBytes(imagePath);
            using (var ms = new MemoryStream(bytes))
            {
                return new Bitmap(ms);
            }
        }

        public static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
