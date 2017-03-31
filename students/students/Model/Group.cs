namespace students.Model
{
    public class Group : Base
    {
        public Group()
        {
        }
        public Group(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
