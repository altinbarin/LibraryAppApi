﻿using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Notifications;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.BorrowedBook;
using Hangfire;

namespace Business.Concrete
{
    public class BorrowedBookService : IBorrowedBookService
    {
        readonly IBorrowedBookRepository _borrowedBookRepository;
        readonly IMapper _mapper;
        readonly IBookRepository _bookRepository;
        readonly IMemberRepository _memberRepository;
        public BorrowedBookService(IBorrowedBookRepository borrowedBookRepository, IMapper mapper, IBookRepository bookRepository, IMemberRepository memberRepository)
        {
            _borrowedBookRepository = borrowedBookRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
        }




        /// <summary>
        /// Ödünç alınan kitap oluşturur.
        /// </summary>
        /// <param name="borrowedBookCreateDto"></param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür</returns>
        public IResult Create(BorrowedBookCreateDTO borrowedBookCreateDto)
        {
            try
            {
                var book = _bookRepository.Get(book => book.Id == borrowedBookCreateDto.BookId && book.Status);
                var borrowedBooks = _borrowedBookRepository.GetAll(borrowedBook => borrowedBook.MemberId == borrowedBookCreateDto.MemberId && borrowedBook.ReturnDate == null).Count;

                //Mail işlemi için üye bilgileri
                var member = _memberRepository.Get(member => member.Id == borrowedBookCreateDto.MemberId && member.Status);


                if(borrowedBooks >= 3)
                    return new ErrorResult(Messages.MemberCanNotBorrowMoreThanThreeBooks);


                if(book.InStock>0)
                {
                    book.InStock -= 1;
                    book.ModifiedDate = DateTime.Now;
                    _bookRepository.Update(book);

                    var borrowedBook = _mapper.Map<BorrowedBook>(borrowedBookCreateDto);
                    borrowedBook.ModifiedDate = DateTime.Now;
                    _borrowedBookRepository.Add(borrowedBook);

                    //Hangfire ile e-posta gönderme işlemi sıraya eklenir
                    SendMail(member.Email, $"{member.Name} {member.Surname}", book.Name);

                    return new SuccessResult(Messages.BorrowedBookCreatedSuccessfully);
                }
                return new ErrorResult(Messages.BookHasNoStock);

            }
            catch (Exception)
            {
                return new ErrorResult(Messages.BorrowedBookCanNotBeCreated);
            }
        }

        /// <summary>
        /// Kullanıcının kitap ödünç alma işlemi başarılı olduğunda gerekli e posta gönderme işlemlerini yapar.
        /// </summary>
        /// <param name="email">Kullanıcı email adresi</param>
        /// <param name="memberFullName">kullanıcının adı ve soyadı</param>
        /// <param name="bookName">kullanıcının ödünç aldığı kitabın adı</param>
        private void SendMail(string email, string memberFullName, string bookName)
        {
            //Kitap ödünç alındığında üyeye e-posta gönderilir
            BackgroundJob.Enqueue<EMailSender>(x => x.SendSuccesfulBorrowingEmail(email,memberFullName, bookName));

            //Kitap ödünç alma süresinin bitişini hatırlatan mail sıraya eklenir (Hangfire)
            BackgroundJob.Schedule<EMailSender>(x => x.Send25WarningEmail(email, memberFullName, bookName), DateTime.Now.AddMinutes(1));

            //Kitap ödünç alma süresinin bittiğini bildiren mail sıraya eklenir (Hangfire)
            BackgroundJob.Schedule<EMailSender>(x => x.Send30DaysWarningEmail(email, memberFullName, bookName), DateTime.Now.AddMinutes(2));

        }

        /// <summary>
        /// Ödünç alınan kitabın iadesini yapar.
        /// </summary>
        /// <param name="borrowedBookId">ödünç alınan kitabın bilgilerinin kimliği</param>
        /// <returns>İşlemin başarı durumunu içeren bir sonuç nesnesi döndürür</returns>
        public IResult BookReturn(int borrowedBookId)
        {
            var borrowedBook = _borrowedBookRepository.Get(borrowedBook => borrowedBook.Id == borrowedBookId && borrowedBook.Status);

            if(borrowedBook == null)
                return new ErrorResult(Messages.BorrowedBookNotFound);

            var book = _bookRepository.Get(book => book.Id == borrowedBook.BookId && book.Status);
            book.ModifiedDate = DateTime.Now;
            book.InStock += 1;
            _bookRepository.Update(book);

            borrowedBook.ModifiedDate = DateTime.Now;
            borrowedBook.DeletedDate = DateTime.Now;
            borrowedBook.Status = false;
            borrowedBook.ReturnDate = DateTime.Now;
            _borrowedBookRepository.Update(borrowedBook);

            return new SuccessResult(Messages.BorrowedBookReturnedSuccessfully);

        }

        /// <summary>
        /// Ödünç alınan kitapları yazar isim-soyismi ve kitap ismi ile birlikte listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetAll()
        {
            var borrowedBooks = _borrowedBookRepository.BorrowedBooksWithAuthorAndBookNames();
            
            if(borrowedBooks == null)
                return new ErrorResult(Messages.BorrowedBookNotFound);

            var borrowedBookDtos = _mapper.Map<List<BorrowedBookListDTO>>(borrowedBooks);
            
            return new SuccessDataResult<List<BorrowedBookListDTO>>(borrowedBookDtos, Messages.BorrowedBooksListedSuccessfully);
            
        }


        /// <summary>
        /// İade edilen kitapları listeler
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür</returns>
        public IResult GetAllBooksReturned()
        {
            var returnedBooks = _borrowedBookRepository.ReturnedBooksWithAuthorAndBookNames();

            if(returnedBooks == null)
                return new ErrorResult(Messages.ReturnedBookNotFound);

            var returnedBookDtos = _mapper.Map<List<ReturnedBookListDTO>>(returnedBooks);
            return new SuccessDataResult<List<ReturnedBookListDTO>>(returnedBookDtos, Messages.ReturnedBooksListedSuccessfully);
        }


        /// <summary>
        /// Belirtilen ödünç alınan kitapların detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak ödünç alınan kitapların kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve verileri içeren bir sonuç nesnesi döndürür.</returns>
        public IResult GetById(int id)
        {
            var borrowedBooks = _borrowedBookRepository.Get(borrowedBook=>borrowedBook.Id == id && borrowedBook.Status);

            if(borrowedBooks == null)
                return new ErrorResult(Messages.BorrowedBookNotFound);

            var borrowedBookDto = _mapper.Map<BorrowedBookDetailDTO>(borrowedBooks);

            return new SuccessDataResult<BorrowedBookDetailDTO>(borrowedBookDto, Messages.BorrowedBookListedSuccessfully);
        }


        
    }

}
