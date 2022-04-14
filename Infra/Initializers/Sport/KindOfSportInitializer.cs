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
                string currentDir = Environment.CurrentDirectory;
                DirectoryInfo directory = new DirectoryInfo(currentDir);
                FileInfo file = new FileInfo("SportList.txt");

                string fullDirectory = directory.FullName + @"\wwwroot\txt\";
                string fileName = "SportList.txt";

                using (StreamReader sr = new StreamReader(@fullDirectory + fileName))
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
                Console.BackgroundColor= ConsoleColor.Red;
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        protected override IEnumerable<KindOfSportData> getEntities
        {
            get
            {
                var l = new List<KindOfSportData>();
                foreach (var s in sportList)
                {
                    var d = createKindOfSport(s,s, "xxx");
                    l.Add(d);
                }
                return l;
            }
        }


        internal static KindOfSportData createKindOfSport(string id, string name, string description)
            => new()
            {
                Id = id  ?? KindOfSportData.NewId,
                Name = name,
                Description = description
            };
    }
}
