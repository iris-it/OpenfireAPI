using System.Collections.Generic;
using System.Text;

namespace OpenfireAPI.entity
{
    public class SystemProperties
    {
        public List<SystemProperty> property { get; set; }

        public override string ToString()
        {
            if (property == null) return "";

            var sb = new StringBuilder();

            foreach (var sp in property)
            {
                sb.Append(sp.ToString());
            }

            return sb.ToString();
        }
    }
}