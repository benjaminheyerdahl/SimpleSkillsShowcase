using Microsoft.EntityFrameworkCore;
using SimpleSkillsShowcase.Core.Entities;
using SimpleSkillsShowcase.Core.Interfaces;
using SimpleSkillsShowcase.Core.ServiceRules;
using SimpleSkillsShowcase.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSkillsShowcase.Core.Implementations
{
    public class NoteService : INoteService
    {
        private NoteContext _context;
        private readonly INoteServiceRule _serviceRule;

        public NoteService(NoteContext context, INoteServiceRule serviceRule)
        {
            _context = context;
            _serviceRule = serviceRule;
        }

        /// <summary>
        /// Get a Note by Id Async.
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <returns>Single Note</returns>
        public async Task<NoteViewModel> GetAsync(int id)
        {
            return await _context.Note
                .Where(n => n.Id == id)
                .Select(note => new NoteViewModel
                {
                    Id = note.Id,
                    Title = note.Title,
                    Description = note.Description
                })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get all Notes Async.
        /// </summary>
        /// <returns>List of Notes</returns>
        public async Task<List<NoteViewModel>> GetAllAsync()
        {
            return await _context.Note
                .Select(note => new NoteViewModel
                {
                    Id = note.Id,
                    Title = note.Title,
                    Description = note.Description
                })
                .ToListAsync();
        }

        /// <summary>
        /// Add a Note.
        /// </summary>
        /// <param name="note">Note</param>
        /// <returns>Success</returns>
        public bool Add(NoteRequestModel note)
        {
            var errors = _serviceRule.Add(note);

            if (errors == null)
            {
                var result = _context.Note.Add(new Note
                {
                    Title = note.Title,
                    Description = note.Description
                });

                if (result.State == EntityState.Added)
                {
                    _context.SaveChanges();
                }
                else
                {
                    // Issue with saving to Db, exists or errors, show here
                    return false;
                }

                return true;
            }
            else
            {
                // Return list of service rule errors here instead, service response model?
                return false;
            }

        }

        /// <summary>
        /// Update a Note.
        /// </summary>
        /// <param name="note">Updated Note</param>
        /// <returns>Updated Note if Success</returns>
        public Note Update(NoteRequestModel note)
        {
            // Maybe return only changes, depends on web use if they will store values.
            var errors = _serviceRule.Update(note);

            if (errors == null)
            {
                var result = _context.Note.Update(new Note
                {
                    Id = note.Id,
                    Title = note.Title,
                    Description = note.Description
                });

                if(result.State == EntityState.Modified)
                {
                    _context.SaveChanges();
                    return result.Entity;
                }
                else
                {
                    // Issue with updating to Db here, show/log errors here
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete a Note by Id.
        /// </summary>
        /// <param name="id">Note Id.</param>
        /// <returns>Success</returns>
        public bool Delete(int id)
        {
            var note = new Note
            {
                Id = id
            };

            var result = _context.Note.Remove(note);

            if (result.State == EntityState.Deleted)
            {
                _context.SaveChanges();
                return true;
            }
            // number of affected rows/success or not
            return false;
        }
    }
}