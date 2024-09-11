namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill()
        {

        }
        public Skill(string description)
        {
            Description = description;
            UserSkills = [];
        }
        public string Description { get; private set; } = string.Empty;
        public List<UserSkill> UserSkills { get; private set; } = new List<UserSkill>();

    }
}
