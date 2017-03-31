using System;
using System.ComponentModel.DataAnnotations;

namespace students.Model
{
    public class Student : Base
    {
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "Телефон")]
        public string ContactPhone { get; set; }

        [Display(Name = "Группа")]
        public Group Group { get; set; }
        public Guid? GroupId { get; set; }

        [Display(AutoGenerateField = false)]
        public bool IsRemoved { get; set; }

        [Display(AutoGenerateField = false)]
        public bool IsOnExpellation { get; set; }
    }
}
