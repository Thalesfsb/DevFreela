namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {

        }
        public User(string fullName, string email, DateTime birthDate, string password, string role)
            : base()
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;
            Password = password;
            Role = role;
            Skills = [];
            OwnedProjects = [];
            FreelanceProjects = [];
            Comments = [];
        }

        public string FullName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; } = DateTime.MinValue;
        public bool Active { get; private set; } = true;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public List<UserSkill> Skills { get; private set; } = new List<UserSkill>();
        public List<Project> OwnedProjects { get; private set; } = new List<Project>();
        public List<Project> FreelanceProjects { get; private set; } = new List<Project>();
        public List<ProjectComment> Comments { get; private set; } = new List<ProjectComment>();
    }
}
