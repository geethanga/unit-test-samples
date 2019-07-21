using System;
using library.data.Contracts;
using library.domain;

namespace library.service
{
    public class MemberService
    {
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<MemberBook> _memberBookRepository;
        private readonly IRepository<Book> _bookRepository;

        public MemberService(IRepository<Book> bookRepository, IRepository<Member> memberRepository, IRepository<MemberBook> memberBookRepository)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
            _memberBookRepository = memberBookRepository;
        }

        public bool BorrowBook(int bookId, int memberId)
        {
            var book = _bookRepository.GetById(bookId);
            var member = _memberRepository.GetById(memberId);

            if (book.AvailableCopies > 1)
            {
                book.AvailableCopies -= 1;
            }
            else
            {
                return false;
            }

            _bookRepository.Save(book);

            _memberRepository.Save(member);

            var memberBook = new MemberBook();
            memberBook.BookId = bookId;
            memberBook.MemberId = memberId;
            memberBook.DateBorrowed = DateTime.Now;

            _memberBookRepository.Save(memberBook);

            return true;
        }
    }
}
