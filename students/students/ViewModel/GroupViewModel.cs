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

namespace group.ViewModel
{
    [POCOViewModel]
    public partial class GroupViewModel
    {

        public GroupViewModel()
        {
            Model = new MainModel();
            GroupList = new ObservableCollection<Group>(Model.GroupRepository);
        }

        private MainModel Model { get; set; }

        public static GroupViewModel Create() => ViewModelSource.Create(() => new GroupViewModel());

              
        [BindableProperty]
        public virtual ObservableCollection<Group> GroupList { get; set; }
        [BindableProperty]        
        public virtual Group SelectedGroup{ get; set; }

        [Command]
        public void Save()
        {
            Model.GroupRepository.AddOrUpdate(GroupList.ToArray());
            Model.SaveChanges();
        }

        [Command]
        public void Refresh()
        {
            GroupList.Clear();
            GroupList.AddRange(Model.GroupRepository.ToList());
        }
        [Command]
        public void NewGroup()
        {
            var newGroup = Model.GroupRepository.Create();
            Model.GroupRepository.Add(newGroup);
            Model.SaveChanges();
            GroupList.Add(newGroup);
            Refresh();
        }
        [Command]
        public void DeleteGroup(Group selectedGroup)
        {
            if (selectedGroup == null) return;
            Model.GroupRepository.Remove(selectedGroup);
            Model.SaveChanges();
            Refresh();
        }
                          
      

    }
}
