using RcTireManager.Data.DTO;
using RcTireManager.Data.Interfaces;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;

namespace RcTireManager.Data
{
    public class BaseTable<T>
    {
        const string DATA_FOLDER = "Data";

        private ObservableCollection<T>? _data;
        private readonly string _name;
        private readonly string _nameAndPath;

        public BaseTable(string Name)
        {
            _name = $"{Name}.json";
            _nameAndPath = Path.Combine(DATA_FOLDER, _name);
            _data = ReadFromDataFile();
        }

        public ObservableCollection<T> GetAll()
        {
            return _data ??= new ObservableCollection<T>();
        }

     

        public void UpdateTable(ObservableCollection<T>? data)
        {
            _data = data ?? new ObservableCollection<T>();
            WriteToDataFile(_data);
        }

      

        private void WriteToDataFile(ObservableCollection<T> data)
        {
            try
            {
                if (!Directory.Exists(DATA_FOLDER))
                    Directory.CreateDirectory(DATA_FOLDER);

                string stream = JsonSerializer.Serialize(data);
                File.WriteAllText(_nameAndPath, stream, Encoding.UTF8);
            }
            catch
            {
                // Logging / Fehlerbehandlung ggf. ergänzen
            }
        }

        private ObservableCollection<T> ReadFromDataFile()
        {
            try
            {
                if (!Directory.Exists(DATA_FOLDER))
                    Directory.CreateDirectory(DATA_FOLDER);

                if (!File.Exists(_nameAndPath))
                {
                    File.WriteAllText(_nameAndPath, string.Empty, Encoding.UTF8);
                    return new ObservableCollection<T>();
                }

                string content = File.ReadAllText(_nameAndPath, Encoding.UTF8);
                if (string.IsNullOrWhiteSpace(content))
                    return new ObservableCollection<T>();

                var deserialized = JsonSerializer.Deserialize<ObservableCollection<T>>(content);
                return deserialized ?? new ObservableCollection<T>();
            }
            catch
            {
                return new ObservableCollection<T>();
            }
        }
    }
}
