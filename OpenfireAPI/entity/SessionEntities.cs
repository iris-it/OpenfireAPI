using System.Collections.Generic;
using System.Text;

namespace OpenfireAPI.entity
{
    public class SessionEntities
    {
        public List<SessionEntity> session { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var se in session)
            {
                sb.Append(se);
            }
            return sb.ToString();
        }
    }
}