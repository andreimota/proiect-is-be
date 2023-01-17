namespace ProiectIS_BE.Models.User
{
    public class UserDashboardModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public List<UserCourseModel> Courses { get; set; }
        public List<UserExerciseModel> Exercises { get; set; }
    }
}
