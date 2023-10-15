using System.ComponentModel.DataAnnotations.Schema;
using EFCoreInterceptor.Data;

namespace EFCoreInterceptor.Models
{
    public class Person : IEntity
    {
        private readonly IPersonRepository personRepository;
        public Person(string name)
        {
            Id = Guid.NewGuid();
            SetName(name);
        }

        protected Person()
        {

        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }


        public void SetName(string name)
        {

            if (!personRepository!.IsExistPersonName(Name))
            {
                Name = name;
            }

            throw new ApplicationException("name is duplicated.");

        }
    }
}
