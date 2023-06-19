using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaWiki
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string SkillName { get; set; }
        public string? SkillDiscription { get; set; }
        public int IDCategory { get; set; }
        public int IDRank { get; set; }

    }
}
