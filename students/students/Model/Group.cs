using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace students.Model
{
    public class Group : Base
    {
        public Group()
        {
        }
        public Group(string fullName)
        {
            FullName = fullName;
        }

        [Display(Name = "Краткое название")]


        public string FullName => GroupType[0] + 
                    Regex.Split(GroupName, "[]").Aggregate("", (current, t) => current + t.ToUpper()[0]) + 
                    "-" + 
                    Year.ToString()[2] + 
                    Year.ToString()[3] + 
                    '-' + 
                    Number;

        [Display(Name = "Тип")]
        public string GroupType {
            get
            {   string[] _GroupType = Name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                return _GroupType[0].ToString();
            }
            set { }
        }

        [Display(Name = "Название")]
        public string GroupName {
            get
            {
                string[] _GroupName = Name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                return _GroupName[1].ToString();
            }
            set { }
        }

        [Display(Name = "Год")]
        public string Year {
            get
            {
                string[] _Year = Name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                return _Year[2].ToString();
            }
            set { }
        }

        [Display(Name = "Подгруппа")]
        public string Number {
            get
            {
                string[] _Number = Name.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                return _Number[3].ToString();
            }
            set { }
        }

        public string Name { get
            {
                return GroupType + '_' + GroupName + '_' + Year + '_' + Number;
            }
            set{}}
    }
}
