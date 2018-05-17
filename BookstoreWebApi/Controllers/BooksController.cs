using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BookstoreWebApi.Dto;
using BookstoreWebApi.Extensions;
using BookstoreWebApi.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        public BooksController()
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<Book>), 200)]
        public IActionResult Search([FromQuery] string title) => Ok();

        [HttpGet]
        [Route("{isdn}")]
        [ProducesResponseType(typeof(Book), 200)]
        [ProducesResponseType(typeof(Book), 404)]
        public IActionResult Get([FromRoute] string isbn) => Ok();

        [HttpPatch]
        [Route("//{isbn}")]
        [ProducesResponseType(typeof(Book), 200)]
        [ProducesResponseType(typeof(Book), 404)]
        public IActionResult Patch([FromRoute] string isbn, [FromBody] BookPatch book) => Ok();
    }
}
