using System.Data.Entity.ModelConfiguration;

namespace students.Model.Map
{
    class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            this.HasKey(k => k.Id);

            this.Property(p => p.FirstName).IsOptional();
            this.Property(p => p.LastName).IsOptional();
            this.Property(p => p.Patronymic).IsOptional();
            this.Property(p => p.GroupId).IsOptional();
            
            ToTable("tbl_Students");
        }
    }
}
