// NOTE: THIS FILE MUST NOT CHANGE

namespace LibData
{
    public class Message
    {
        public string type { get; set; }
        public string content { get; set; }
    }

    public class MessageType
    {
        public const string hello = "Hello";
        public const string welcome = "Welcome";
        public const string bookInquiry = "BookInquiry";
        public const string userInquiry = "UserInquiry";
        public const string bookInqReply = "BookInquiryReply";
        public const string userInqReply = "UserInquiryReply";
        public const string endComm = "EndCommunication";
        public const string error = "Error";
        public const string notFound = "NotFound";
    }

    public class BookData
    {
        public string title { get; set; }
        public string author { get; set; }
        public string status { get; set; }
        public string borrowedBy { get; set; }
        public string ReturnDate { get; set; }
    }

    public class UserData
    {
        public string user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
