using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMPhoenix.ViewModel
{
    public class ResponseViewModel
    {
        public ResponseViewModel()
        {
            status = 0;
            message = string.Empty;
        }
        public string message { get; set; }
        public object responseData { get; set; }
        public int status { get; set; }
        public int Total { get; set; }
    }
    public class Constants
    {

        public const string Error = "Some Internal Error Occurred";
        public const string Success = "Data Saved Successfully";
        public const string Delete = "Data Deleted Successfully";
        public const string Warning = "Data Is Not In Proper Format";
        public const string Retreived = "Data Retrieved Successfully";
        public const string NotFound = "Data Not Found";
        public const string Exist = "Data Already Exist";
        public const string Login = "Login Successfully";
        public const string LoginFail = "Invalid UserName or Password";
        public const string DefaultPath = "/Content/images/Servcorp/avatar5.png";
        public const string InsertionFail = "Please Try Again";
        public const string ImagePath = "/Images/ProfilePic/";
        public const string FilePath = "/FileUploaded/Files/";
        public const string GenerateLink = "Please generate link again";
        public const string InvalidUser = "Please select valid user name";
        public const string InvalidPassword = "Please enter valid old password";
        public const string CancelReservationFailed = "Refund is already done";
        public const string CancelReservationSuccess = "Amount will be refunded to your account in seven working days";
        public const string uploadSuccess = "uploaded successfully";
        public const string updateSuccess = "Data Updated Successfully";
        public const string LocalesPath = "~/Scripts/Locales/";
    }
}
