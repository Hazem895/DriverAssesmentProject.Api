using AssesmentProject.Domain.DriversDomain;
using AssesmentProject.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssesmentProject.Infrastructure.Sql.Repository.DriversRepository
{
    public class DriversRepository : ICrudCommandsRepository<Driver>
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Driver> _DriversSet;

        public DriversRepository(ApplicationDbContext context)
        {
            _context = context;
            _DriversSet = _context.Drivers;
        }

        public async Task<string> Create(Driver Input)
        {

            if (await ReadById(Input.DriverId) != null )
            {
                throw new Exception("Already Exist");
            }
            else
            {
                Input.DriverId = Guid.NewGuid();
                await _DriversSet.AddAsync(Input);
                await _context.SaveChangesAsync();
                return $"{Input.DriverId} Added Successfully";
            }
        }

        public async Task<string> Delete(Guid ID)
        {
            Driver? record =await ReadById(ID);
            if (record != null)
            {
                _DriversSet.Remove(record);
                await _context.SaveChangesAsync();
                return $"{ID} deleted Successfully";
            }
            else
            {
                throw new Exception("Not Exist");

            }
        }

        public async Task<List<Driver>> ReadAll()
        {
            return await _DriversSet.ToListAsync();
        }

        public async Task<Driver?> ReadById(Guid? Id)
        {
            return await _DriversSet.SingleOrDefaultAsync(x => x.DriverId == Id);
        }

        public async Task<string> Update(Driver Input, Guid ID)
        {
            Driver? record = await ReadById(ID);
            if (record != null)
            {
                #region editing model to assign for the same Id
                record.Firstname = Input.Firstname;
                record.Lastname = Input.Lastname;
                record.Email = Input.Email;
                record.PhoneNumber = Input.PhoneNumber;
                #endregion

                _DriversSet.Update(record);
                await _context.SaveChangesAsync();

                return $"{ID} Updated Successfully";
            }
            else
            {
                throw new Exception("Not Exist");
            }
        }
    }
}
