using Microsoft.EntityFrameworkCore;
using lastoneapi.studu;
using lastoneapi.Data;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Components.Forms;

namespace lastoneapi.repo
{
    public class repo2 : repo
    {
        private readonly Db _context;

            public repo2 (Db context)
        {
             _context = context;
        }

        //get the data in an excel shit
        public async Task<IEnumerable<input>> GetAllAsync() 
             
        {
            
            return await  _context.input.ToListAsync();

        }

        //search the data by the id 
        public async Task<input> GetbyidAsync(int id) 
        {

            return await _context.input.FindAsync(id);

        }

        // create the excel shit
        public async Task<input> CreateAsync(input input)
        {

            _context.input.Add(input);

            await  _context.SaveChangesAsync();

            return input;

        }

        // updating
        public async Task<input> UpdateAsync(int id, input input)
        {
            var upo = await _context.input.FindAsync(id);
            if (upo == null) return null;

            upo.name = input.name;
            upo.age = input.age;
            upo.semester = input.semester;

            await _context.SaveChangesAsync();
            return upo;

        }


        // wow delete
        public async Task<bool> DeleteAsync(int id)
        {

            var delo = await _context.input.FindAsync(id);
            if(delo == null) return false;

            await _context.SaveChangesAsync();
            return true;

        }

        internal async Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
