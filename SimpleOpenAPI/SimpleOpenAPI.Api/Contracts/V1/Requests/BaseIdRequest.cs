using System;
using Microsoft.AspNetCore.Mvc;

namespace SimpleOpenAPI.Api.Contracts.V1.Requests
{
    public abstract class BaseIdRequest
    {
        /// <summary>
        /// Book id
        /// </summary>
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}