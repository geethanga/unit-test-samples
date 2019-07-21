using System;
using library.domain;

namespace library.service.Contracts
{
    public interface IMemberService
    {
        Member CreateMember();
        bool BorrowBook(int bookId, int memberId);
        bool ReturnBook(int bookId, int memberId);
    }
}
