namespace EFCoreInterceptor.Data
{
    public interface IPersonRepository
    {
        bool IsExistPersonName(string name);
    }

    public class PersonRepository : IPersonRepository
    {
        public bool IsExistPersonName(string name)
        {
            return true;
        }
    }
}
