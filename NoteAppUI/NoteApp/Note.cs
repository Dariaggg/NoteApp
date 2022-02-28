using System;

namespace NoteApp
{
    /// <summary>
    /// Класс заметки, хранящий информацию о заголовке, категории, тексте и времени создания и изменении
    /// </summary>
    public class Note
    {
        private string _name = "Без названия";
        private NoteCategory _noteCategory;
        private string _noteText;
        private DateTime _creationTime;
        private DateTime _lastChangeTime;

        /// <summary>
        /// Возвращает и задает название заметки
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException($"Длина названия не может превышать 50 символов");
                }
                _name = value;
                _lastChangeTime = DateTime.Now;
            }
        }
        /// <summary>
        ///  Возвращает и задает категорию заметки
        /// </summary>
        public NoteCategory NoteCategory
        {
            get
            {
                return _noteCategory;
            }
            set
            {
                _noteCategory = value;
                _lastChangeTime = DateTime.Now;
            }
        }
        /// <summary>
        /// Возвращает и задает текст заметки
        /// </summary>
        public string NoteText
        {
            get
            {
                return _noteText;
            }
            set
            {
                _noteText = value;
                _lastChangeTime = DateTime.Now;
            }
        }
        /// <summary>
        /// Возвращает и задает время создания заметки
        /// </summary>
        public DateTime CreationTime { get; }

        /// <summary>
        /// Возвращает и задает время последнего изменения заметки
        /// </summary>
        public DateTime LastChangeTime { get; }

        /// <summary>
        /// Создание заметки
        /// </summary>
        public Note(string name, NoteCategory noteCategory, string noteText, DateTime creationTime, DateTime lastChangeTime)
        {
            Name = name;
            NoteCategory = noteCategory;
            NoteText = noteText;
            CreationTime = DateTime.Now;
            LastChangeTime = lastChangeTime;
        }

        public Note()
        {
            _creationTime = DateTime.Now;
        }

    }
}
