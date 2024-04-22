﻿using LinqToDB.Mapping;

namespace BookStore
{
    [Table(Name = "Book")]
    public class Book
    {
        [PrimaryKey, Identity] public int bookId { get; set; }
        [Column] public string title { get; set; }
        [Column] public int authorId { get; set; }
        [Association(ThisKey = nameof(authorId), OtherKey = nameof(Author.authorId))]
        public Author author { get; set; }

        [Column] public string isbn13 { get; set; }
        [Column] public int languageId { get; set; }
        [Association(ThisKey = nameof(languageId), OtherKey = nameof(BookLanguage.languageId))]
        public BookLanguage language { get; set; }
        [Column] public int numPages { get; set; }
        [Column] public int publicationDate { get; set; }
        [Column] public int publisherId { get; set; }
        [Association(ThisKey = nameof(publisherId), OtherKey =nameof(Publisher.publisherId))]
        public Publisher publisher{ get; set; }
        [Column] public int genreId { get; set; }
        [Association(ThisKey = nameof(genreId), OtherKey = nameof(Genre.genreId))]
        public Genre genre { get; set; }
        [Column] public double price { get; set; }
    }
}
