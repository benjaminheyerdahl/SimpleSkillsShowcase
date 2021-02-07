using SimpleSkillsShowcase.Core.Entities;
using SimpleSkillsShowcase.Core.Implementations;
using SimpleSkillsShowcase.Core.Interfaces;
using SimpleSkillsShowcase.Core.ServiceRules.Implementations;
using SimpleSkillsShowcase.Core.ViewModels;
using Xunit;

namespace SimpleSkillsShowcaseTests.NoteTests
{
    public class NoteServiceTest
    {
        private readonly INoteService _service;
        private readonly NoteServiceRule _serviceRule;
        private NoteContext _context;

        public NoteServiceTest()
        {
            _service = new NoteService(_context, _serviceRule);
        }
        // No Moq needed for these simple cases

        [Fact]
        public void AddNote_ValidInput_NoErrors()
        {
            var note = new NoteRequestModel
            {
                Title = "Test",
                Description = "Description"
            };

            var result = _service.Add(note);

            Assert.True(result);

        }

        [Fact]
        public void AddNote_InvalidInput_Errors()
        {
        }
    }
}