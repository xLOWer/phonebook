using System;
using System.ComponentModel.DataAnnotations;

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
        public string FullName { get
            {   
                string _FullName;
                _FullName = GroupType.Substring(0, 1);
                string[] _GroupName = GroupName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i=0; i< _GroupName.Length; i++)
                {
                    _FullName = _FullName + _GroupName[i].ToString().Substring(0, 1);
                }
                _FullName = _FullName + Year.Substring(2, 2) + '-' + Number;

                return _FullName ;
            }
            set { } }

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
