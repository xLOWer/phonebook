using System;

namespace phoneapp1.Model
{
    public class PeopleModel
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        //public DepartmentModel Dep { get; set; }
        #endregion

    }

    //public class DepartmentModel
    //{
    //    #region Properties

    //    public string Name { get; set; }
    //    #endregion

    //}
}