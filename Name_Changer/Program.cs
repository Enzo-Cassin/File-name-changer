using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Name_Changer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            string path = @"\path"; // Alterar a string para o caminho desejado
            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string extension = Path.GetExtension(file);

                fileName = RemoveAccents(fileName);

                fileName = Regex.Replace(fileName, @"\s+|[.,;_]", "-");
                while (fileName.Contains("--"))
                {
                    fileName = Regex.Replace(fileName, @"--", "-");
                }
                
                fileName += Path.GetExtension(file);
                string newpath = path + fileName;

                File.Move(file, newpath);
            }
            Console.WriteLine("All files names were changed.");
        }

        public static string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();

            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }

            return sbReturn.ToString();
        }

    }
}
