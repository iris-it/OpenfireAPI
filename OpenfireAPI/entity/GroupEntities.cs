using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OpenfireAPI.entity
{
    public class GroupEntities : IEnumerable
    {
        public List<GroupEntity> group { get; set; }

        public override string ToString()
        {
            if (group == null) return "";

            var sb = new StringBuilder();

            foreach (var ge in group)
            {
                sb.Append(ge);
            }
            return sb.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}