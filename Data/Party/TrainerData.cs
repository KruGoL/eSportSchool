namespace eSportSchool.Data.Party
{
    public sealed class TrainerData : UniqueData
    {
        public string? FirstName { get; set; }
        public  string? LastName { get; set; }
        public IsoGender? Gender { get; set; }
        public DateTime? DoB { get; set; }
    }
}
