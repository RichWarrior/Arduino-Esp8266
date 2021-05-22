
namespace Core.Utilities
{
    public static class Messages
    {
        public static string Successful => "Successful";
        public static string Error => "Error";
        
        public static class User
        {
            public static string AlreadyExists =>"Such a user already exists";
            public static string NotRegistered => "User could not be registered";
            public static string NotLogIn => "Could not login";
        }
    }
}
