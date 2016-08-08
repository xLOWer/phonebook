using System;
using phonebook.Model;

namespace phonebook
{
    public class ViewModel
    {
        #region Constructor
        public ViewModel()
        {
            People = new PeopleModel
            {
                FirstName = "First name",
                LastName = "Last name"
            };
        }

        #endregion

        #region Properties

        public PeopleModel[] People { get; set; }

        #endregion
    }
}