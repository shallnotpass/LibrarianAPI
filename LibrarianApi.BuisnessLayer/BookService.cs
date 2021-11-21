using LibrarianApi.BuisnessLayer.Contracts;
using LibrarianApi.BuisnessLayer.Models;
using LibrarianApi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.BuisnessLayer
{
    public class BookService : IBookService
    {
        private readonly ApplicationContext dbContext;

        public BookService(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> Add(IBookExpanDto book)
        {
            var bookDbo = new Book()
            {
                Article = book.Article,
                Name = book.Name,
                Year = book.Year,
                Author = new Author()
                {
                    FirstName = book.Author.FirstName,
                    SecondName = book.Author.SecondName,
                    Patronymic = book.Author.Patronymic
                },
                BookAccounting = new BookAccounting()
                {
                    AvailableCount = book.AvailableCount,
                    TotalCount = book.TotalCount
                },
                IsDeleted = false,
                UserCardEntries = new List<UserCardEntry>()
                
            };
            dbContext.Books.Add(bookDbo);
            dbContext.SaveChanges();
            return 1;
        }

        public async Task<int> Delete(int bookId)
        {
            var book = dbContext.Books.Find(bookId);
            if (book != null)
            {
                book.IsDeleted = true;
                dbContext.Update(book);
                dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<IBookDto>> FindBookByName(string name)
        {
            return dbContext.Books.Where(x => x.Name.Contains(name) && x.IsDeleted != true)
                .Select(x => new BookDto() 
                {
                    Author = new AuthorDto() 
                    {
                        FirstName = x.Author.FirstName,
                        Patronymic = x.Author.Patronymic,
                        SecondName = x.Author.SecondName
                    }, 
                    Name = x.Name, 
                    Year = x.Year 
                }).ToList();
        }

        public async Task<IEnumerable<IBookDto>> GetAvalableBooks()
        {
            return dbContext.Books.Where(x => x.IsDeleted != true).Select(x => new BookDto()
            {
                Author = new AuthorDto() 
                { 
                    FirstName = x.Author.FirstName, 
                    SecondName = x.Author.SecondName,
                    Patronymic = x.Author.Patronymic
                },
                Name = x.Name,
                Year = x.Year
            }).ToList();
        }

        public async Task<IEnumerable<IBookDto>> GetBooklistByUserId(int userId)
        {
            var userDbo = dbContext.Users.FirstOrDefault(x => x.Id == userId && x.IsDeleted != true);
            if (userDbo != null)
            {
                return userDbo.UserCardEntries.Select(x => x.Book).Select(x => new BookDto() 
                {
                    Author = new AuthorDto 
                    { 
                        FirstName = x.Author.FirstName, 
                        Patronymic = x.Author.Patronymic, 
                        SecondName = x.Author.SecondName 
                    },
                    Name = x.Name,
                    Year= x.Year
                }).ToList();
            }
            return null;
        }

        public async Task<IBookExpanDto> GetInfoById(int bookId)
        {
            var bookDbo = dbContext.Books.Find(bookId);
            if (bookDbo == null) return null;
            if (bookDbo.IsDeleted != true)
            {
                var bookDto = new BookExpanDto()
                {
                    Article = bookDbo.Article,
                    Author = new AuthorDto()
                    {
                        FirstName = bookDbo.Author.FirstName,
                        SecondName = bookDbo.Author.SecondName,
                        Patronymic = bookDbo.Author.Patronymic
                    },
                    AvailableCount = bookDbo.BookAccounting.AvailableCount,
                    TotalCount = bookDbo.BookAccounting.TotalCount,
                    Name = bookDbo.Name,
                    Year = bookDbo.Year
                };
                return bookDto;
            }
            return null;
        }

        public async Task<int> Update(IBookExpanDto book, int bookId)
        {
            var bookDbo = dbContext.Books.FirstOrDefault(x=>x.Id == bookId);
            if (bookDbo != null)
            {
                if (bookDbo.IsDeleted != true)
                {
                    bookDbo.Article = bookDbo.Article;
                    bookDbo.Author = new Author()
                    {
                        FirstName = book.Author.FirstName,
                        SecondName = book.Author.SecondName,
                        Patronymic = book.Author.Patronymic
                    };
                    bookDbo.BookAccounting = new BookAccounting()
                    {
                        AvailableCount = book.AvailableCount,
                        TotalCount = book.TotalCount
                    };
                    bookDbo.Name = book.Name;
                    bookDbo.Year = book.Year;
                    dbContext.Update(bookDbo);
                    dbContext.SaveChanges();
                    return 1;
                }
            }
            return 0;
        }
    }
}
