namespace HebrewSchool.Models.School
{
    /* Модель фамилии ученика */
    public class Surname
    {
        public int Id { get; set; }
        public string? RuSurname { get; set; } // Фамилия на русском языке
        public string? HebSurname { get; set; } // Фамилия на иврите
    }
}
