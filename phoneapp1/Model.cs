using System;

namespace phonebook
{
    public class PeopleModel
    {
        #region Properties

        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        #endregion

    }

    public class DepartmentModel
    {
        #region Properties

        public string Name { get; set; }
        public PeopleModel[] employees { get; set; }

        #endregion

    }
}