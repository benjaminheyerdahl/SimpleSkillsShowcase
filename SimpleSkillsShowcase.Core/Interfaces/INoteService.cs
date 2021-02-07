using SimpleSkillsShowcase.Core.Entities;
using SimpleSkillsShowcase.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSkillsShowcase.Core.Interfaces
{
    public interface INoteService
    {
        Task<NoteViewModel> GetAsync(int id);

        Task<List<NoteViewModel>> GetAllAsync();

        bool Add(NoteRequestModel note);

        Note Update(NoteRequestModel note);

        bool Delete(int id);
    }
}
