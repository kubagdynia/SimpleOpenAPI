using System;
using Microsoft.AspNetCore.Mvc;

namespace SimpleOpenAPI.Api.Contracts.Requests
{
    public class DeleteBookRequest
    {
        /// <summary>
        /// Book id
        /// </summary>
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}