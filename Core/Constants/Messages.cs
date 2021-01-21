using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Constants
{
    public static class Messages
    {
        public static string PersonAddedSuccess= "person is registered successfully";
        public static string PersonAddedNotRegistered = "person is not registered";
        public static string PersonNameAlreadyExists= "This person has been registered before";

        public static string PersonNotExist = "This person not exist";
        public static string PersonRemoveSuccess = "person has been deleted";
        public static string PersonUpdateSuccess = "person has been updated";

        public static string ContactRemoveSuccess = "contact has been deleted";
        public static string ContactAddedSuccess = "contact info is registered successfully";
        public static string ContactNotExist = "This contact not exist";
        public static string ContactPhoneNumberExit = "This phone number has been registered before";
    }
}
