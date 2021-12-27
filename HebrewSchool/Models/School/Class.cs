namespace HebrewSchool.Models.School
{
    /* Модель класса */
    public class Class
    {
        public int Id { get; set; }
        public int? Number { get; set; }  // Номер класса
        public string? Letter { get; set; } // Буква класса
        public ICollection<Student> Students { get; set; } // Список учеников в классе

        public Class()
        {
            this.Students = new List<Student>();
        }
    }
}
