using System;
using System.ComponentModel.DataAnnotations;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;

namespace students.Model
{ 
    public class Subject : Base
    {
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Тип")]
        public string Type { get; set; }

        [Display(Name = "Аудитория")]
        public string LectureHall { get; set; }

        public ObservableCollection<Group> SubjectOfGroup { get; set; }
        public ObservableCollection<Teacher> SubjectOfTeacher { get; set; }
    }
}