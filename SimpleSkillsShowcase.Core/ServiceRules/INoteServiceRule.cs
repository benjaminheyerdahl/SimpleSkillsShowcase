using SimpleSkillsShowcase.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSkillsShowcase.Core.ServiceRules
{
    public interface INoteServiceRule
    {
        // Return list of Errors or Messages or Values from failed validation.
        List<string> Add(NoteRequestModel note);

        List<string> Update(NoteRequestModel note);
    }
}
