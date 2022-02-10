

using eSportSchool.Data;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Facade
{
    public class PersonViewFactory
    {
        public Person Create(PersonView v) => new(new PersonData() {
           
                Id = v.Id,
                DoB = v.DoB,
                Gender = v.Gender,
                FirstName = v.FirstName,
                LastName = v.LastName
        });
    
        public PersonView Create(Person o)=> new() {
                Id = o.Id,
                DoB = o.DoB,
                Gender = o.Gender,
                FirstName = o.FirstName,
                LastName = o.LastName,
                FullName = o.ToStrnig(),
        };
    
    }
}
