using eSportSchool.Data.Sport;
using eSportSchool.Domain;

namespace eSportSchool.Infra.Initializers.Sport
{
    public sealed class KindOfSportInitializer : BaseInitializer<KindOfSportData>
    {
        private List<string> sportList = new List<string> { };

        public KindOfSportInitializer(eSportSchoolDB? db) : base(db, db?.KindOfSports)
        {
            try
            {
                using (StreamReader sr = new StreamReader("SportList.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        sportList.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        protected override IEnumerable<KindOfSportData> getEntities
        {
            get
            {
                var l = new List<KindOfSportData>();
                foreach (var s in sportList)
                {
                    var d = createKindOfSport("xxx", "xxx", "xxx");
                    l.Add(d);
                }
                return l;
            }
        }


        internal static KindOfSportData createKindOfSport(string code, string name, string description)
            => new()
            {
                Id = code ?? KindOfSportData.NewId,
                Code = code ?? UniqueEntity.DefaultStr,
                Name = name,
                Description = description
            };
    }
}
