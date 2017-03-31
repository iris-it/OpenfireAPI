namespace OpenfireAPI.entity
{
    public class GroupEntity
    {
        public string name { get; set; }
        public string description { get; set; }

        public override string ToString()
        {
            return "name: " + name + ", description: " + description+"\n";
        }
    }
}
