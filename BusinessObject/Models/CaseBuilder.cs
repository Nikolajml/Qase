namespace UI.Models
{
    public class CaseBuilder
    {
        private Case Case;

        public CaseBuilder()
        {
            Case = new Case();
        }

        public CaseBuilder SetCaseTitle(string title)
        {
            Case.Title = title;
            return this;
        }

        public CaseBuilder SetDescription(string description)
        {
            Case.Description = description;
            return this;
        }

        public CaseBuilder SetCode(string code)
        {
            Case.Code = code;
            return this;
        }

        public Case Build()
        {
            return Case;
        }
    }
}
