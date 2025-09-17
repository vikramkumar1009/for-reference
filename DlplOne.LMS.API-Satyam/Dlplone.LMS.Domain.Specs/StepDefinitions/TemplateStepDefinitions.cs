using Moq;
using Dlplone.LMS.Domain.Infrastructure;
using Dlplone.LMS.Entities;
using TechTalk.SpecFlow.Assist;

namespace Dlplone.LMS.Domain.Specs.StepDefinitions
{
    [Binding]
    public sealed class TemplateStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private readonly ITemplateService _templateService;
        private readonly Mock<IPartnerRepository> moqRepo;
        private  int id;
        private  Templates? _result;
        List<Templates> templates = new List<Templates>();
        public TemplateStepDefinitions()
        {
                moqRepo = new Mock<IPartnerRepository>();
               
                 templates.Add(new Templates { Id = 1, TemplateName = "Doctor Email", Template = "Dummy Template" });
                 moqRepo.Setup(re => re.FindByIdAsync<Templates>(It.IsAny<int>(),It.IsAny<string>(),It.IsAny<string>()))
                 .ReturnsAsync((int _Id, string _, string _)
                     =>
                      {
                          return templates.FirstOrDefault(t => t.Id == _Id);
                      });
                _templateService =  new TemplateService(moqRepo.Object);
        }

        [Given(@"template id will be (.*)")]
        public void GivenTemplateIdWillBe(int templateId)
        {
           id = templateId;
        }


        [When(@"GetTemplateAsync will be called")]
        public async Task WhenGetTemplateAsyncWillBeCalled()
        {
            _result =  await _templateService.GetTemplateAsync(id);
        }


        [Then(@"the returned template will be")]
        public void ThenTheReturnedTemplateWillBe(Table table)
        {
            moqRepo.Verify(m => m.FindByIdAsync<Templates>(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            var data = table.CreateInstance<Templates>();
            _result.Should().BeEquivalentTo(data);
        }

        [Then(@"the returned template should be null")]
        public void ThenTheReturnedTemplateShouldBeNull()
        {
            moqRepo.Verify(m => m.FindByIdAsync<Templates>(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), Times.AtLeastOnce);
            _result.Should().BeNull();
        }


    }
}
