using students.Model.Map;

namespace students.Model
{
    using System.Data.Entity;

    public class MainModel : DbContext
    {
        public MainModel() : base("name=StudentsModel")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new GroupMap());
        }

        public DbSet<Student> StudentRepository { get; set; }
        public DbSet<Group> GroupRepository { get; set; }
    }
}