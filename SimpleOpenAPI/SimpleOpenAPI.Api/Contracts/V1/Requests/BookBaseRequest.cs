using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleOpenAPI.Api.Contracts.V1.Requests
{
    public abstract class BookBaseRequest
    {
        [Required]
        public string Title { get; set; }
        
        [DefaultValue(0)]
        public int PageCount { get; set; }
        
        public string Isbn { get; set; }
        
        public DateTime PublicationDate { get; set; }
        
        public string AuthorName { get; set; }
        
        public string ShortDescription { get; set; }
        
        public string Publisher { get; set; }
        
        public string Url { get; set; }
    }
}