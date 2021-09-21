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
        // the name of the book
        public string title { get; set; }
        // the author of the book
        public string author { get; set; }
        // the availability of the book: can be either Available or Borrowed
        public string status { get; set; }
        //the user id of the person who borrowed the book, otherwise null if the book is available.
        public string borrowedBy { get; set; }
        // return date of a book if it is borrowed, otherwise null.
        public string ReturnDate { get; set; }
    }

    public class UserData
    {
        // user id: has the format User-[a number]
        public string user_id { get; set; }
        // full name
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
