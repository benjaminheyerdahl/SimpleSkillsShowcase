using SimpleSkillsShowcase.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSkillsShowcase.Core.ServiceRules.Implementations
{
    public class NoteServiceRule : INoteServiceRule
    {
        private List<string> errors;

        public NoteServiceRule()
        {
        }

        public List<string> Add(NoteRequestModel note)
        {
            if (note.Id > 0)
            {
                errors.Add("Id must not be greater than 0");
            }

            if (string.IsNullOrEmpty(note.Title))
            {
                errors.Add("Title must not be empty");
            }

            return errors;
        }

        // check if item exists to update
        public List<string> Update(NoteRequestModel note)
        {
            if (note.Id < 1)
            {
                errors.Add("Id must not be greater than 0");
            }

            if (string.IsNullOrEmpty(note.Title))
            {
                errors.Add("Title must not be empty");
            }

            return errors;
        }
    }
}
