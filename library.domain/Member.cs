using System;
namespace library.domain
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BorrowedQty { get; set; }
        public int BorrowingLimit { get; set; }
    }
}
