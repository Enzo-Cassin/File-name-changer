using System.Collections.Generic;
using System.Threading.Channels;

namespace Name_Changer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Change this variable to the path where the directory names you want  to be changed
            string path = @"\path";
            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string extension = Path.GetExtension(file);
                string newName = "";
                for(int i = 0; i < fileName.Length; i++)
                {
                    if (fileName[i] == 'Á' || fileName[i] == 'À' || fileName[i] == 'Ã' || fileName[i] == 'Â')
                    {
                        newName += 'A';
                    } 
                    else if (fileName[i] == 'á' || fileName[i] == 'à' || fileName[i] == 'ã' || fileName[i] == 'â')
                    {
                        newName += 'a';
                    } 
                    else if (fileName[i] == 'É' || fileName[i] == 'È' || fileName[i] == 'Ê')
                    {
                        newName += 'E';
                    }
                    else if (fileName[i] == 'é' || fileName[i] == 'è' || fileName[i] == 'ê')
                    {
                        newName += 'e';
                    }
                    else if (fileName[i] == 'Í' || fileName[i] == 'Ì' || fileName[i] == 'Î')
                    {
                        newName += 'I';
                    }
                    else if (fileName[i] == 'í' || fileName[i] == 'ì' || fileName[i] == 'î')
                    {
                        newName += 'i';
                    }
                    else if (fileName[i] == 'Ó' || fileName[i] == 'Ò' || fileName[i] == 'Õ' || fileName[i] == 'Ô')
                    {
                        newName += 'O';
                    }
                    else if (fileName[i] == 'ó' || fileName[i] == 'ò' || fileName[i] == 'õ' || fileName[i] == 'ô')
                    {
                        newName += 'o';
                    }
                    else if (fileName[i] == 'Ú' || fileName[i] == 'Ù' || fileName[i] == 'Û')
                    {
                        newName += 'U';
                    }
                    else if (fileName[i] == 'ú' || fileName[i] == 'ù' || fileName[i] == 'û')
                    {
                        newName += 'u';
                    }
                    else if (fileName[i] == 'Ç')
                    {
                        newName += 'C';
                    }
                    else if (fileName[i] == 'ç')
                    {
                        newName += 'c';
                    }
                    else if (fileName[i] == ' ' || fileName[i] == '.' || fileName[i] == ',' || fileName[i] == ';' || fileName[i] == '_')
                    {
                        newName += '-';
                    }
                    else
                    {
                        newName += fileName[i];
                    }
                }
                newName += extension;
                string newpath = path + newName;
                
                File.Move(file, newpath);
            }
            Console.WriteLine("All files names were changed.");
        }
        
    }
}
