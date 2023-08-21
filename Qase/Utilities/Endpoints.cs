namespace Core.Utilities
{
    public class Endpoints
    {
        public static readonly string CREATE_PROJECT = "v1/project";
        public static readonly string GET_PROJECT = "v1/project/{code}";
        public static readonly string DELETE_PROJECT = "v1/project/{code}";

        public static readonly string CREATE_SUITE = "v1/suite/{code}";
        public static readonly string GET_SUITE = "v1/suite/{code}/{id}";
        public static readonly string UPDATE_SUITE = "v1/suite/{code}/{id}";
        public static readonly string DELETE_SUITE = "v1/suite/{code}/{id}";

        public static readonly string CREATE_CASE = "v1/case/{code}";
        public static readonly string GET_CASE = "v1/case/{code}/{id}";
        public static readonly string UPDATE_CASE = "v1/case/{code}/{id}";
        public static readonly string DELETE_CASE = "v1/case/{code}/{id}";

        public static readonly string CREATE_PLAN = "v1/plan/{code}";
        public static readonly string GET_PLAN = "v1/plan/{code}/{id}";
        public static readonly string UPDATE_PLAN = "v1/plan/{code}/{id}";
        public static readonly string DELETE_PLAN = "v1/plan/{code}/{id}";

        public const string CREATE_DEFECT = "v1/defect/{code}";
        public const string GET_DEFECT = "v1/defect/{code}/{id}";
        public const string UPDATE_DEFECT = "v1/defect/{code}/{id}";
        public const string DELETE_DEFECT = "v1/defect/{code}/{id}";
    }
}
