namespace Core.Utilities
{
    public class Endpoints
    {
        public const string CREATE_PROJECT = "v1/project";
        public const string GET_PROJECT = "v1/project/{code}";
        public const string DELETE_PROJECT = "v1/project/{code}";

        public const string CREATE_SUITE = "v1/suite/{code}";
        public const string GET_SUITE = "v1/suite/{code}/{id}";
        public const string UPDATE_SUITE = "v1/suite/{code}/{id}";
        public const string DELETE_SUITE = "v1/suite/{code}/{id}";

        public const string CREATE_CASE = "v1/case/{code}";
        public const string GET_ALL_CASE = "v1/case/{code}";
        public const string GET_CASE = "v1/case/{code}/{id}";
        public const string UPDATE_CASE = "v1/case/{code}/{id}";
        public const string DELETE_CASE = "v1/case/{code}/{id}";

        public const string CREATE_PLAN = "v1/plan/{code}";
        public const string GET_PLAN = "v1/plan/{code}/{id}";
        public const string UPDATE_PLAN = "v1/plan/{code}/{id}";
        public const string DELETE_PLAN = "v1/plan/{code}/{id}";

        public const string CREATE_DEFECT = "v1/defect/{code}";
        public const string GET_ALL_DEFECT = "v1/defect/{code}";
        public const string GET_DEFECT = "v1/defect/{code}/{id}";
        public const string UPDATE_DEFECT = "v1/defect/{code}/{id}";
        public const string DELETE_DEFECT = "v1/defect/{code}/{id}";
    }
}
