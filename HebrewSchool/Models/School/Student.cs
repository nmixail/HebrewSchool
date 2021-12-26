namespace HebrewSchool.Models.School
{
    
    public class Student
    {
        public int Id { get; set; }
        public Name Name { get; set; } // Полное имя ученика
        public Surname Surname { get; set; } // Полная фамилия ученика
        public string LoginItalam { get; set; } // Логин для входа на сайт Italam
        public string PasswordItalam { get; set; } // Пароль для входа на сайт Italam
    }
}
