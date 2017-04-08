using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace students.Model
{
    public class Group : Base
    {
        public Group()
        {
        }
       
        [Display(Name = "Краткое название")]
        [NotMapped]
        public string FullName => GroupType.ToUpper()[0] + 
                    Regex.Split(GroupName, "[]").Aggregate("", (current, t) => current + t.ToUpper()[0]) + 
                    "-" + 
                    Year.ToString()[2] + 
                    Year.ToString()[3] + 
                    '-' + 
                    Number;

        [Display(Name = "Тип")]
        public string GroupType { get; set; }

        [Display(Name = "Название")]
        public string GroupName { get; set; }

        [Display(Name = "Год")]
        public DateTime Year => Year;

        [Display(Name = "Подгруппа")]
        public string Number {get;set;}

        public ObservableCollection<Student> StudentOfGroup { get; set; }
    }
}
