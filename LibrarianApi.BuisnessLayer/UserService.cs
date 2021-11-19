using LibrarianApi.BuisnessLayer.Contracts;
using LibrarianApi.BuisnessLayer.Models;
using LibrarianApi.DataAccess;

namespace LibrarianApi.BuisnessLayer
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext dbContext;

        public UserService(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(IUserDto user)
        {
            var userDbo = new User()
            {
                Birthday = user.Birthday,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Patronymic = user.Patronymic,
                UserCardEntries = new List<UserCardEntry>()
            };

            dbContext.Users.Add(userDbo);
            dbContext.SaveChanges();
        }

        public void AddBook(int userId, int bookId)
        {
            var user = dbContext.Users.Find(userId);
            if (user != null && user.IsDeleted != true)
            {
                var book = dbContext.Books.Find(bookId);

                if (book != null && book.IsDeleted != true)
                {
                    if (book.BookAccounting.AvailableCount != 0)
                    {
                        var userCardEntry = new UserCardEntry()
                        {
                            BookId = bookId,
                            UserId = userId
                        };
                        dbContext.UserCardEntries.Add(userCardEntry);
                        book.BookAccounting.AvailableCount -= 1;
                        book.UserCardEntries.Add(userCardEntry);
                        user.UserCardEntries.Add(userCardEntry);
                        dbContext.Update(book);
                        dbContext.Update(user);
                        dbContext.SaveChanges();
                    }
                }
            }
        }

        public void Delete(int id)
        {
            var user = dbContext.Users.Find(id);
            if (user != null)
            {
                user.IsDeleted = true;
                dbContext.Update(user);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<IUserDto> FindByFullName(string term)
        {
            return dbContext.Users
                .Where(x => x.FirstName.Contains(term) || x.SecondName.Contains(term) || x.Patronymic.Contains(term))
                .Select(x => new UserDto()
                {
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    Patronymic = x.Patronymic,
                    Birthday = x.Birthday
                })
                .ToList();
        }

        public IUserInfoDto GetUserInfo(int userId)
        {

            var user = dbContext.Users.Find(userId);
            if (user != null && user.IsDeleted != true)
            {
                return new UserInfoDto()
                {
                    Birthday = user.Birthday,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    Patronymic = user.Patronymic,
                    Books = user.UserCardEntries.Where(x => x.IsDeleted != true && x.Book.IsDeleted != true).Select(x => new BookDto
                    {
                        Author = new AuthorDto()
                        {
                            FirstName = x.Book.Author.FirstName,
                            SecondName = x.Book.Author.SecondName
                        },
                        Name = x.Book.Name,
                        Year = x.Book.Year
                    })
                };
            }
            return null;
        }

        public void ReturnBook(int userId, int bookId)//
        {
            var user = dbContext.Users.Find(userId);
            if (user != null && user.IsDeleted != true)
            {
                var book = dbContext.Books.Find(bookId);
                if (book != null && book.IsDeleted != true)
                {
                    var entry = dbContext.UserCardEntries.FirstOrDefault(x => x.BookId == book.Id && x.IsDeleted != true);
                    if (entry != null)
                    {
                        entry.IsDeleted = true;
                        var changedEntry = new UserCardEntry() { Book = entry.Book, User = entry.User, IsDeleted = true };
                        book.BookAccounting.AvailableCount += 1;
                        dbContext.Update(changedEntry);
                        dbContext.Update(book.BookAccounting);
                        dbContext.SaveChanges();
                    }
                }
            }
        }

        public void Update(IUserDto user, int userId)
        {
            var userDbo = dbContext.Users.Find(userId);
            if (userDbo != null)
            {
                userDbo.FirstName = user.FirstName;
                userDbo.SecondName = user.SecondName;
                userDbo.Patronymic = user.Patronymic;
                userDbo.Birthday = user.Birthday;
                dbContext.Update(userDbo);
                dbContext.SaveChanges();
            }
        }
    }
}