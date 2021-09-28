// NOTE: THIS FILE MUST NOT CHANGE

namespace LibData
{

    public class Message
    {
        public MessageType Type { get; set; }
        public string Content { get; set; }
    }

    public enum MessageType
    {
        Hello,
        Welcome,
        BookInquiry,
        UserInquiry,
        BookInquiryReply,
        UserInquiryReply,
        EndCommunication,
        Error,
        NotFound,
    }

    public class BookData
    {
        // the name of the book
        public string Title { get; set; }
        // the author of the book
        public string Author { get; set; }
        // the availability of the book: can be either Available or Borrowed
        public string Status { get; set; }
        //the user id of the person who borrowed the book, otherwise null if the book is available.
        public string BorrowedBy { get; set; }
        // return date of a book if it is borrowed, otherwise null.
        public string ReturnDate { get; set; }
    }

    public class UserData
    {
        // user id: has the format User-[a number]
        public string User_id { get; set; }
        // full name
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
