using System;
using phoneapp1.Model;
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Windows;

namespace phoneapp1.ViewModel
{
    [POCOViewModel]
    public class EditViewModel
    {
        public EditViewModel()
        {
            People = new PeopleModel();
        }

        public EditViewModel(PeopleModel p)
        {
            People = p;
        }

        [BindableProperty]
        public virtual PeopleModel People { get; set; }

        public void SavePeople()
        {
            Messenger.Default.Send(new Message(People));
        }
    }

    public class Message
    {
        
        public PeopleModel People { get; set; }

        public Message(PeopleModel p)
        {
            People = p; 
        }
        
    }

    [POCOViewModel]
    public class MainViewModel
    {
        //public static MainViewModel Create()
        //{
        //    return ViewModelSource.Create(() => new MainViewModel());
        //}

        #region Constructor
        public MainViewModel()
        {
            //Department = new DepartmentModel[]
            //{
            //    new DepartmentModel { Name = "Sell" },
            //    new DepartmentModel { Name = "Admn" },
            //};

            Messenger.Default.Register<Message>(this, OnReceive);

            People = new ObservableCollection<PeopleModel>
            {
                new PeopleModel { Id = 0, Name = "Василий", LastName = "Пупкин", Patronymic = "Александрович", Phone = "+7-999-000-00-01" },
                new PeopleModel { Id = 1, Name = "Александр", LastName = "Васичкин", Patronymic = "Васильевич", Phone = "+7-999-000-00-02" },
                new PeopleModel { Id = 2, Name = "Дмитрий", LastName = "Шишло", Patronymic = "Михайлович", Phone = "+7-999-000-00-03" },
                new PeopleModel { Id = 3, Name = "Пётр", LastName = "Порошенко", Patronymic = "Алексеевич", Phone = "+7-999-000-00-04" },
                new PeopleModel { Id = 4, Name = "Максим", LastName = "Петров", Patronymic = "Дмитриевич", Phone = "+7-999-000-00-05" },
                new PeopleModel { Id = 5, Name = "Алексей", LastName = "Помогаев", Patronymic = "Петрович", Phone = "+7-999-000-00-06" },
                new PeopleModel { Id = 6, Name = "Юлия", LastName = "Кузнецова", Patronymic = "Александровна", Phone = "+7-999-000-00-07" },
                new PeopleModel { Id = 7, Name = "Анастасия", LastName = "Гельманова", Patronymic = "Александровна", Phone = "+7-999-000-00-08" },
                new PeopleModel { Id = 8, Name = "София", LastName = "Шалапута", Patronymic = "Михайловна", Phone = "+7-999-000-00-09" },
                new PeopleModel { Id = 9, Name = "Виктория", LastName = "Хрулёва", Patronymic = "Александровна", Phone = "+7-999-000-00-10" },
                new PeopleModel { Id = 10, Name = "Даниил", LastName = "Криванков", Patronymic = "Дмитриевич", Phone = "+7-999-000-00-11" },
                new PeopleModel { Id = 11, Name = "Наталья", LastName = "Любомудрова", Patronymic = "Петровна", Phone = "+7-999-000-00-12" }
            };
        }

        [Command]
        public void AddPeople()
        {
            AddPeople addp = new phoneapp1.AddPeople();
            EditViewModel evm = ViewModelSource.Create(() => new EditViewModel());
            addp.DataContext = evm;
            addp.Show();
            int MaxId = 0;
            foreach(PeopleModel o in People) MaxId = MaxId < o.Id ? o.Id+1 : MaxId+1;
            addp.textBox_Id.Text = MaxId.ToString();
        }

        [Command]
        public void DeletePeople(PeopleModel p)
        {
            People.Remove(p);
        }

        public void OnReceive(Message o)
        {
            if (People.Contains(o.People))
            {
                People.Remove(o.People);
                
            }
            People.Add(o.People);
        }

        #endregion

        #region Properties
        [BindableProperty]
        public virtual ObservableCollection<PeopleModel> People { get; set; }
        [BindableProperty]
        public virtual PeopleModel SinglePeople { get; set; }
        //public PeopleModel[] People { get; set; }
        //public DepartmentModel[] Department { get; set; }
        #endregion
    }
}