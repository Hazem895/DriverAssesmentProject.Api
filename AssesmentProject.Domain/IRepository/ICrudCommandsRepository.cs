using AssesmentProject.Domain.DriversDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssesmentProject.Domain.IRepository
{
    /// <summary>
    /// Generic Interface for default Crud operations
    /// </summary>
    /// <typeparam name="T">the Domain model associated with Dbset</typeparam>
    public interface ICrudCommandsRepository<T> where T : class
    {
        /// <summary>
        /// Create new record in Database
        /// </summary>
        /// <param name="Input">data model to be added</param>
        /// <returns>the Id of record created</returns>
        Task<string> Create(T Input);
        /// <summary>
        /// Get Data from Database
        /// </summary>
        /// <returns>set of all data</returns>
        Task<List<T>> ReadAll();
        /// <summary>
        /// gets a specific record based on given Id
        /// </summary>
        /// <param name="Id">Id of record to get</param>
        /// <returns>a specific record based on given Id</returns>
        Task<T> ReadById(Guid? Id);
        /// <summary>
        /// Update existing record in database
        /// </summary>
        /// <param name="Input">new updated data</param>
        /// <param name="ID">the id of record to update</param>
        /// <returns>the Id of record updated</returns>
        Task<string> Update(T Input, Guid ID);
        /// <summary>
        /// Delete existing record in database
        /// </summary>
        /// <param name="ID">id of record to delete</param>
        /// <returns>the Id of record deleted</returns>
        Task<string> Delete(Guid ID);
    }
}
