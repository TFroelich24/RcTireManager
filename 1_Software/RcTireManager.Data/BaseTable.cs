using RcTireManager.Data.DTO;
using RcTireManager.Data.Interfaces;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RcTireManager.Data
{
    public class BaseTable<T>
    {
        const string DATA_FOLDER = "Data";

        ObservableCollection<T>? _data;
        string _name;
        string _nameAndPath;
        FileStream _file;

        public BaseTable(string Name)
        {
            _name = $"{Name}" + ".json";
            _nameAndPath = Path.Combine("Data\\", _name);
            readFromDataFile();
        }

        public ObservableCollection<T> GetAll()
        {
            return readFromDataFile();
        }

        public T? GetById()
        {
            return default;
        }

        public void Add(T item)
        {
            ObservableCollection<T> data = readFromDataFile() ?? new ObservableCollection<T>();
            data.Add(item);
            writeToDataFile(data);
        }

        public void AddIfNotExistsOrUpdate(T item)
        {
            ObservableCollection<T> data = readFromDataFile() ?? new ObservableCollection<T>();
            if (!data.Contains(item))
                data.Add(item);
            else
            {
                for (int i = 0; i < data.Count; i++)
                    if (data !=null&& data[i].Equals(item))
                        data[i] = item;
            }

            writeToDataFile(data);
        }


        private void writeToDataFile(ObservableCollection<T> data)
        {
            string stream = JsonSerializer.Serialize(data);
            createOrOpenDataFile();
            _file.Position = 0;
            _file.Write(Encoding.ASCII.GetBytes(stream));
            _file.Close();
        }


        private ObservableCollection<T> readFromDataFile()
        {
            createOrOpenDataFile();

            if (_file == null)
                return new ObservableCollection<T>();

            else if (_file.Length == 0)
            {
                _file.Close();
                return new ObservableCollection<T>();
            }
            else
            {
                _data = (ObservableCollection<T>)JsonSerializer.Deserialize<ObservableCollection<T>>(_file);
                _file.Close();
                return _data;
            }
        }

        private void createOrOpenDataFile()
        {
            if (!Directory.Exists("Data"))
                Directory.CreateDirectory("Data");
            if (!File.Exists(_nameAndPath))
                File.Create(_nameAndPath).Close();
            else
            {
                _file = File.Open(_nameAndPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
        }
    }
}
