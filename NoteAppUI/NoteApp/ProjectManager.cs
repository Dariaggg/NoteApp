using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp
{
    public class ProjectManager
    {
        /// <summary>
        /// Kонстанта, содержащая путь.
        /// </summary>
        private static string _path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
        @"\source\repos\NoteApp\NoteAppUI\NoteAppUI\bin\Debug\netcoreapp3.1\NoteApp.json";

        public static void SaveToFile(Project data, string file)
        {
            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };

            ////Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(file))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, data);
            }

        }
        /// <summary>
        /// Сохранения списка заметок в путь по умолчанию
        /// </summary>
        /// <param name="data">список заметок </param>
        public static void SaveToFile(Project data)
        {
            SaveToFile(data, _path);
        }
        public static Project LoadFromFile(string file)
        {
            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            //Открываем поток для чтения из файла с указанием пути
            using (StreamReader sr = new StreamReader(file))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
                return (Project)serializer.Deserialize<Project>(reader);
            }
        }
        /// <summary>
        /// Загрузка списка из файла в путь по умолчанию
        /// </summary>
        /// <returns>Возвращает список заметок</returns>
        public static Project LoadFromFile()
        {
            return LoadFromFile(_path);
        }

    }
}
