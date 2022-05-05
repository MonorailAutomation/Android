using System;
using static monorail_android.Database.RetrieveUser;
using static monorail_android.RestRequests.Endpoints.AzureFunctions.UserSuspensionFunction;
using static monorail_android.RestRequests.Endpoints.Management.CloseMonorailAccount;

namespace monorail_android.RestRequests.Helpers
{
    public static class UserManagementHelperFunctions
    {
        /*
         CloseUser(string email) 
         Sets 'isDeleted' flag as true. We don't have any mechanism to unlock such user again. 
         Daily jobs will NOT be run for such user. 
         We will use this function for all users EXCEPT the Orbis ones.
         
         SuspendUser(string email) 
         Sets 'isSuspended' flag as true. We are able to unlock such user.
         Daily jobs will be run for such user.
         We will use this function ONLY for the Orbis users.
         */
        public static void CloseUser(string email)
        {
            var userId = GetUserId(email);
            PostMonorailCloseUserId(userId);
            Console.WriteLine(email + " was closed successfully");
        }

        public static void SuspendUser(string email)
        {
            var userId = GetUserId(email);
            GetUserSuspensionFunction(userId);
            Console.WriteLine(email + " was suspended successfully");
        }
    }
}