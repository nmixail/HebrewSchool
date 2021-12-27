namespace HebrewSchool.Models.Account
{
    /* Модель пользователей */
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; } // Логин пользователя
        public string? Password { get; set; } // Пароль пользователя
        public string? Email { get; set; } // Email пользователя
        public string? Role { get; set; } // Роль пользвателя
        public string? Salt { get; set; } // Соль для шифрования пароля пользователя
    }
}
