namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description, List<UserSkill> userSkills)
        {
            Description = description;
            UserSkills = userSkills;
        }

        public string Description { get; private set; } 
        public List<UserSkill> UserSkills { get; private set; }
    }
}
