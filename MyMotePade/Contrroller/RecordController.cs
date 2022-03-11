using MyNotePade.Model; // ссылка на  модель
using System; 
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyNotePade.Contrroller
{
    internal class RecordController
    {
        public List<Record> Records { get; set; } //записи
        private string _path;  // путь  к файлу  

        public RecordController(string path)
        {
            _path = path;
            Records = RunRecord();
        }
        /// <summary>
        /// загрузка из файла
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<Record> RunRecord()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    List<Record> rec = formatter.Deserialize(fs) as List<Record>;
                    fs.Close();
                    if (rec != null)
                        return rec;
                    else
                        return new List<Record>();
                }
            }
            catch (SerializationException ex)
            {
                return new List<Record>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void SaveRecorFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Records);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(string content  , string  status)
        {
            Records.Add(new Record(content, status));
            try
            {
                SaveRecorFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
//      \\192.168.10.160\задание