using System.ComponentModel.DataAnnotations.Schema;

namespace HebrewSchool.Models.School
{
    /* Модель учебного года */
    public class Year
    {
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; } // Дата(год) начала учебного года

        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; } // Дата(год) конца учебного года

        public ICollection<Class> Classes { get; set; } // Список классов в учебном году
    }
}
