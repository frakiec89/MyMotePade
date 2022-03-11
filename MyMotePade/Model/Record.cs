using System;
namespace MyNotePade.Model
{ 
    [Serializable] // буду сериализовать 
    /// <summary>
    /// описание  одной записи в записной  книжке
    /// </summary>
    internal class Record
    {
        public string Content { get; set; }
        public DateTime DateRecord { get; private set; } //  дата  не  меняется
        public string Status { get; set; }

        public Record(string content, string status) // конструктор
        {
            Content = content;
            DateRecord = DateTime.Now; // текущая  дата
            Status = status;
        }

        public override string ToString()
        {
            return $"Дата: {DateRecord}, статус: {Status}\n" +
                $"{Content}\n";
        }
    }
}