using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarianApi.BuisnessLayer.Models
{
    public class BookExpanDto : BookDto, IBookExpanDto
    {
        public string Article { get; set; }
        public int TotalCount { get; set; }
        public int AvailableCount { get; set; }
    }
    public interface IBookExpanDto : IBookCountDto, IBookDto
    {
        public string Article { get; set; }
    }
    public class BookDto : IBookDto
    {
        public string Name { get; set; }
        public string Year { get; set; }
        public AuthorDto Author { get; set; }
    }
    public interface IBookDto
    {
        string Name { get; set; }
        string Year { get; set; }
        AuthorDto Author { get; set; }
    }
    public interface IBookCountDto
    {
        int TotalCount { get; set; }
        int AvailableCount { get; set; }
    }
    public class AuthorDto : IAuthorDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
    }
    public interface IAuthorDto
    {
        string FirstName { get; set; }
        string SecondName { get; set; }
        string Patronymic { get; set; }
    }
}
