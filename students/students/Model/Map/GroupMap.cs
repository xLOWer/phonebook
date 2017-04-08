using System.Data.Entity.ModelConfiguration; 

namespace students.Model.Map
{
    class GroupMap : EntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            this.HasKey(k => k.Id);

            this.Property(p => p.GroupType).IsOptional();
            this.Property(p => p.GroupName).IsOptional();
            this.Property(p => p.Year).IsOptional();
            this.Property(p => p.Number).IsOptional();

            ToTable("tbl_Groups");
        }
    }
}
