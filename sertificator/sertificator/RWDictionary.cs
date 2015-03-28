using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sertificator
{
    static class RwDictionary   // чтение и запись данных в виде словаря 
    {
        public static string Company {  get; private set; }
        public static int NumberLines {  get; private set; }
    

        static public Dictionary<int, string> ReadDictionary(string filePath)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            using (FileStream fs =
                new FileStream(filePath, FileMode.Open,
                    FileAccess.Read, FileShare.Read))
            {
                fs.Seek(0, SeekOrigin.Begin);
                // Теперь прочитаем данные из файла
                BinaryReader br = new BinaryReader(fs);

                // Запишем данные в result
                Company = br.ReadString();
                NumberLines = br.ReadInt32();

                for (int i = 0; i < NumberLines; i++)
                {
                    result.Add(br.ReadInt32(), br.ReadString());
                }
                Console.WriteLine("Данные считаны из файла");
                return result;
            }
        }

        static public void WriteDictionary(string filePath, Dictionary<int, string> dictionary, string company)
        {
           NumberLines = dictionary.Count;
           
                using (FileStream fs =
                    new FileStream(filePath, FileMode.Create,
                        FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    BinaryWriter bw = new BinaryWriter(fs);

                    // Запишем данные в поток
                    bw.Write(company);
                    bw.Write(NumberLines);
                    foreach (var list in dictionary)
                    {
                        bw.Write(list.Key);
                        bw.Write(list.Value);
                    }
                    // Сохраним данные из буфера на диск
                    bw.Flush();
                    Console.WriteLine("Данные записаны в файл");
                }
            }


        }
}

