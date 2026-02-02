using RcTireManager.Data.Interfaces;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;

namespace RcTireManager.Data
{
    public class BaseTable<T> :IBaseTable<T>
    {
        const string DATA_FOLDER = "Data";

        ObservableCollection<T>? _data;
        string _name;
        string _nameAndPath;
        FileStream? _file;

        public BaseTable(string Name)
        {
            _name = $"{Name}" + ".json";
            _nameAndPath = DATA_FOLDER+"\\"+ _name;
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
            File.Delete(_nameAndPath);
            writeToDataFile(data);
        }

        public void UpdateTable(ObservableCollection<T>? data)
        {
            File.Delete(_nameAndPath);
            string stream = JsonSerializer.Serialize(data);

            if (data != null)
            {
                File.Create(_nameAndPath).Close();
                _file = File.Open(_nameAndPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                _file.Position = 0;
                _file.Write(Encoding.ASCII.GetBytes(stream));
                _file.Close();
            }
        }

        public void AddIfNotExistsOrUpdate(T item)
        {
            ObservableCollection<T> data = readFromDataFile() ?? new ObservableCollection<T>();
            if (!data.Contains(item))
                data.Add(item);
            else
            {
                for (int i = 0; i < data.Count; i++)
                    if (data != null && data[i].Equals(item))
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
            if (!Directory.Exists(DATA_FOLDER))
                Directory.CreateDirectory(DATA_FOLDER);
            if (!File.Exists(_nameAndPath))
                File.Create(_nameAndPath).Close();
            else
            {
                _file = File.Open(_nameAndPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
        }
    }
}
