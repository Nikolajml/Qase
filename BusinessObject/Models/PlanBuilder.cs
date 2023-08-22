namespace UI.Models
{
    public class PlanBuilder
    {
        private Plan plan;

        public PlanBuilder()
        {
            plan = new Plan();
        }

        public PlanBuilder SetPlanTitle(string title)
        {
            plan.Title = title;
            return this;
        }

        public PlanBuilder SetPlanDescription(string description)
        {
            plan.Description = description;
            return this;
        }

        public Plan Build()
        {
            return plan;
        }
    }
}
