namespace OpenfireAPI.entity
{
    public class MessageEntity
    {
        public string body { get; set; }
        public override string ToString()
        {
            return body;
        }
    }
}
