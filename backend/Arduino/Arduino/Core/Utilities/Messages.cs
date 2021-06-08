
namespace Core.Utilities
{
    public static class Messages
    {
        public static string Successful => "Successful";
        public static string Error => "Error";
        public static string UnAuthorized => "Unauthorized";

        public static class User
        {
            public static string AlreadyExists =>"Such a user already exists";
            public static string NotRegistered => "User could not be registered";
            public static string NotLogIn => "Could not login";
            public static string NotFound => "User not found";
        }

        public static class DeviceType
        {
            public static string NotFound => "Device type not found";
        }

        public static class Device
        {
            public static string NotInserted => "Could not created device";
            public static string NotDeleted => "Could not deleted device";
            public static string NotUpdated => "Could not updated device";
        }

        public static class DeviceDetail
        {
            public static string NotInserted => "Could not created device detail";
        }

        public static class Sensor
        {
            public static string NotFound => "Sensor Not Found";
        }
    }
}
