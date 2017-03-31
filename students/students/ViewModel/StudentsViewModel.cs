using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity.Migrations;

using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.CodeView;

using students.Model;

namespace students.ViewModel
{
    [POCOViewModel]
    public partial class StudentsViewModel
    {

        public StudentsViewModel()
        {
            Model = new MainModel();
            StudentList = new ObservableCollection<Student>(Model.StudentRepository);
            GroupList = new ObservableCollection<Group>(Model.GroupRepository);
        }

        private MainModel Model { get; set; }

        public static StudentsViewModel Create() => ViewModelSource.Create(() => new StudentsViewModel());

        [BindableProperty]
        public virtual ObservableCollection<Student> StudentList { get; set; }
        [BindableProperty]
        public virtual ICollection<Student> ExpelledStudentList
        {
            get { return StudentList.Where(w => w.IsOnExpellation == true).ToList(); }
            set { }
        } 
        [BindableProperty]
        public virtual ObservableCollection<Group> GroupList { get; set; }
        [BindableProperty]
        public virtual bool IsReadOnly { get; set; }
        [BindableProperty]        
        public virtual Student SelectedStudent { get; set; }

        [Command]
        public void Save()
        {
            Model.StudentRepository.AddOrUpdate(StudentList.ToArray());
            Model.GroupRepository.AddOrUpdate(GroupList.ToArray());
            Model.SaveChanges();
        }

        [Command]
        public void Refresh()
        {
            StudentList.Clear();
            StudentList.AddRange(Model.StudentRepository.ToList());
            GroupList.Clear();
            GroupList.AddRange(Model.GroupRepository.ToList());
        }
        [Command]
        public void NewStudent()
        {
            var newStudent = Model.StudentRepository.Create();
            Model.StudentRepository.Add(newStudent);
            Model.SaveChanges();
            StudentList.Add(newStudent);
            Refresh();
        }
        [Command]
        public void DeleteStudent(Student selectedStudent)
        {
            if (selectedStudent == null) return;
            Model.StudentRepository.Remove(selectedStudent);
            Model.SaveChanges();
            Refresh();
        }
        [Command]
        public void TurnOnExpelledStudent(Student selectedStudent)
        {
            selectedStudent.IsOnExpellation = true;
            Refresh();
        }          
        [Command]
        public void TurnOffExpelledStudent(Student selectedStudent)
        {
            selectedStudent.IsOnExpellation = false;
            Refresh();
        }

        [BindableProperty]
        public virtual bool IsOnExpellation
        {
            get
            {
                return SelectedStudent != null && !SelectedStudent.IsOnExpellation;
            }
            set { }
        }

    }
}
