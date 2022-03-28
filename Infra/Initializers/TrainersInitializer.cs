using eSportSchool.Data.Party;

namespace eSportSchool.Infra.Initializers
{
    public class TrainersInitializer : BaseInitializer<TrainerData>
    {
        public TrainersInitializer(eSportSchoolDB? db) : base(db, db?.Trainers) { }
        internal static TrainerData createTrainer(string firstName, string lastName, bool gender, DateTime dayOfBirth)
        {
            var trainer = new TrainerData
            {
                Id = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                DoB = dayOfBirth
            };
            return trainer;
        }
        protected override IEnumerable<TrainerData> getEntities => new[] {
            createTrainer("Usain", "Bolt", false, new DateTime(1977, 07, 01)),
            createTrainer("Killer", "Call", true, new DateTime(1920, 09, 19)),
            createTrainer("Tiny", "Toons", false, new DateTime(1968, 02, 01)),
        };
    }
}