using eSportSchool.Data.Party;

namespace eSportSchool.Infra.Initializers
{
    public class TrainersInitializer : BaseInitializer<TrainerData>
    {
        public TrainersInitializer(eSportSchoolDB? db) : base(db, db?.Trainers) { }
        internal static TrainerData createTrainer(string firstName, string lastName, IsoGender gender, DateTime dayOfBirth)
        {
            var trainer = new TrainerData
            {
                Id = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                FullName = firstName + " " + lastName,
                Gender = gender,
                DoB = dayOfBirth
            };
            return trainer;
        }
        protected override IEnumerable<TrainerData> getEntities => new[] {
            createTrainer("Usain", "Bolt", IsoGender.Female, new DateTime(1977, 07, 01)),
            createTrainer("Killer", "Call", IsoGender.Male, new DateTime(1920, 09, 19)),
            createTrainer("Tiny", "Toons", IsoGender.NotKnown, new DateTime(1968, 02, 01)),
        };
    }
}