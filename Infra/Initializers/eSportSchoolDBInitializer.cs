using eSportSchool.Infra.Initializers.Combined;
using eSportSchool.Infra.Initializers.Sport;

namespace eSportSchool.Infra.Initializers
{
    public static class eSportSchoolDBInitializer
    {
        public static void Init(eSportSchoolDB? db)
        {
            new AddressesInitializer(db).Init();
            new TrainersInitializer(db).Init();
            new SportTeamsInitializer(db).Init();
            new CountriesInitializer(db).Init();
            new CurrenciesInitializer(db).Init();
            new KindOfSportInitializer(db).Init();
            new TrainerSportTeamsInitializer(db).Init();
        }
    }
}
