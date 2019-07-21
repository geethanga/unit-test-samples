using System;
namespace library.domain
{
    public class MemberBook
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DateReturned { get; set; }
    }
}
