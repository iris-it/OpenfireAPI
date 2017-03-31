using System.Collections.Generic;
using System.Text;

namespace OpenfireAPI.entity
{
    public class RosterEntity
    {
        public string jid { get; set; }
        public string nickname { get; set; }
        public string subscribtionType { get; set; }
        public List<RosterGroup> groups { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (jid != null) sb.Append(jid + " ");

            if (nickname != null) sb.Append(nickname + " ");

            if (subscribtionType != null) sb.Append(nickname + " ");

            if (groups == null) return sb.ToString();

            sb.Append("gropus: ");

            foreach (var group in groups) sb.Append(group + " ,");

            return sb.ToString();
            //return String.Format("jid: {0}, nickname:{1}, subtype:{2}, goups:{3}", jid, nickname, subscribtionType, groups.ToString());
        }
    }
}