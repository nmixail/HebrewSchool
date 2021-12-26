namespace HebrewSchool.Models.School
{
    /* Модель имени ученика */
    public class Name
    {
        public int Id { get; set; }
        public string RuName { get; set; } // Имя на русском языке
        public string HebName { get; set; } // Имя на иврите
    }
}
