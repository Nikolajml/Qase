
using BusinessObject.Models;
using BusinessObject.Services;
using Core.Client;

namespace Core.Utilities
{
    public class EntityHandler
    {
        public List<Case> CasesForDelete = new();
        public static List<Defect> DefectsForDelete = new();

        public CaseService _caseService = new CaseService(new ApiClient());
        public static DefectService _defectService = new DefectService(new ApiClient());

        public void DeleteCases()
        {
            foreach (var caseForDelete in CasesForDelete)
            {
                _caseService.DeleteSuite(caseForDelete);
            }
        }

        public static void DeleteDefects()
        {
            foreach (var defectForDelete in DefectsForDelete)
            {
                _defectService.DeleteDefect(defectForDelete, "");
            }
        }

    }
}
