using System.Collections.Generic;

namespace OpenfireAPI.entity
{
    public class UserEntity
    {
        public string username { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<UserProperty> properties { get; set; }
    }
}