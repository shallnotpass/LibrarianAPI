namespace LibrarianApi.DataAccess
{
    public class User : BaseEntity
    {
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }

        public List<UserCardEntry> UserCardEntries = new List<UserCardEntry>();
    }
}