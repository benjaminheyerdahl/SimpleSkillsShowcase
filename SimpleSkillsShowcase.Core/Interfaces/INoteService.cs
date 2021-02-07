using SimpleSkillsShowcase.Core.Entities;
using SimpleSkillsShowcase.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleSkillsShowcase.Core.Interfaces
{
    public interface INoteService
    {
        /// <summary>
        /// Get a Note by Id Async.
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <returns>Single Note</returns>
        Task<NoteViewModel> GetAsync(int id);

        /// <summary>
        /// Get all Notes Async.
        /// </summary>
        /// <returns>List of Notes</returns>
        Task<List<NoteViewModel>> GetAllAsync();

        /// <summary>
        /// Add a Note.
        /// </summary>
        /// <param name="note">Note</param>
        /// <returns>Success</returns>
        bool Add(NoteRequestModel note);

        /// <summary>
        /// Update a Note.
        /// </summary>
        /// <param name="note">Updated Note</param>
        /// <returns>Updated Note if Success</returns>
        Note Update(NoteRequestModel note);

        /// <summary>
        /// Delete a Note by Id.
        /// </summary>
        /// <param name="id">Note Id.</param>
        /// <returns>Success</returns>
        bool Delete(int id);
    }
}