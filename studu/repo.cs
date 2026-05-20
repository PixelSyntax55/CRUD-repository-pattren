using lastoneapi.studu;

namespace lastoneapi.repo
{

    public class repo
    {
        public interface Irepo
        {

            Task <List<input>> GetAll();

            Task<input> GetById(int id);

            Task Add(input student);

            Task delete(int id);

        }

    }
}