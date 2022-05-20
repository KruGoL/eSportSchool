
namespace eSportSchool.Infra.Initializers
{
    public static class eSportSchoolDBInitializer
    {
        public static void Init(eSportSchoolDB? db)
        {
            new TrainersInitializer(db).Init();
            new SportTeamsInitializer(db).Init();
            new KindOfSportInitializer(db).Init();
            new TrainerSportTeamsInitializer(db).Init();
        }
    }
}
