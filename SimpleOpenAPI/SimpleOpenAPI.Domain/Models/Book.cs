using System;

namespace SimpleOpenAPI.Domain.Models
{
    public class Book
    {
        public long InternalId { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }
        
        public int PageCount { get; set; }
        
        public string Isbn { get; set; }
        
        public DateTime PublicationDate { get; set; }
        
        public string AuthorName { get; set; }
        
        public string ShortDescription { get; set; }
        
        public string Publisher { get; set; }
        
        public string Url { get; set; }
    }
}