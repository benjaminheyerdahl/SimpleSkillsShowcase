using Microsoft.EntityFrameworkCore;
using SimpleSkillsShowcase.Core.Entities;
using SimpleSkillsShowcase.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSkillsShowcase.Core.Interfaces
{
    public class NoteService: INoteService
    {
        private NoteContext _context;

        public NoteService(NoteContext context)
        {
            _context = context;
        }

        public async Task<NoteViewModel> GetAsync(int id)
        {
            return await _context.Note
                .Where(n => n.Id == id)
                .Select(note => new NoteViewModel
                    {
                        Id = note.Id,
                        Title = note.Title
                    })
                .FirstOrDefaultAsync();
        }

        public async Task<List<NoteViewModel>> GetAllAsync()
        {
            return await _context.Note
                .Select(note => new NoteViewModel
                    {
                        Id = note.Id
                    })
                .ToListAsync();
        }

        public bool Add(NoteRequestModel note)
        {
            var result = _context.Note.Add(new Note
            {
                Title = note.Title
            });

            _context.SaveChanges();

            return true;
        }

        public Note Update(NoteRequestModel note)
        {
            var result = _context.Note.Update(new Note
            {
                Id = note.Id
            });

            _context.SaveChanges();

            return result.Entity;
        }

        public bool Delete(int id)
        {
            //var result = _context.Notes.Remove(id);

            //if (result != null)
            //{
            //    return false;
            //}
            //// number of affected rows/success or not
            return true;
        }
    }
}
