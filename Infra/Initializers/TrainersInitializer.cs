using eSportSchool.Data;
using eSportSchool.Data.Party;

namespace eSportSchool.Infra.Initializers
{
    public class TrainersInitializer : BaseInitializer<TrainerData>
    {
        public TrainersInitializer(eSportSchoolDB? db) : base(db, db?.Trainers) { }
        internal static TrainerData createTrainer(string firstName, string lastName, IsoGender gender, DateTime dayOfBirth,string imgPath = "default.jpg")
        {
            var trainer = new TrainerData
            {
                Id = UniqueData.NewId,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                DoB = dayOfBirth,
                ImgPath = imgPath
            };
            return trainer;
        }
        protected override IEnumerable<TrainerData> getEntities => new[] {
            createTrainer("Usain", "Bolt", IsoGender.Male, new DateTime(1977, 07, 01),"bolt.jpg"),
            createTrainer("Killer", "Call", IsoGender.Female, new DateTime(1920, 09, 19)),
            createTrainer("Tiny", "Toons", IsoGender.NotKnown, new DateTime(1968, 02, 01)),
        };
    }
}