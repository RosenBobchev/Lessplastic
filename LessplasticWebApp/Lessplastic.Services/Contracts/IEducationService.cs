using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Educations;

namespace Lessplastic.Services.Contracts
{
    public interface IEducationService
    {
        Education GetEducation(int id);

        Education[] GetEducations();

        int CreateEducation(EducationViewModel model);

        void EditEducation(Education education, UpdateDeleteEducationViewModel model);

        void DeleteEducation(Education education);
    }
}
