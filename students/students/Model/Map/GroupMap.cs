using System.Data.Entity.ModelConfiguration; 

namespace students.Model.Map
{
    class GroupMap : EntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            this.HasKey(k => k.Id);

            this.Property(p => p.Name).IsOptional();

            ToTable("tbl_Groups");
        }
    }
}
