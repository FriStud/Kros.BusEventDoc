﻿using Kros.EventBusDoc.Demo.Data;
using Kros.EventBusDoc.Demo.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kros.EventBusDoc.Demo.Controlers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDemoRepository repository;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(IDemoRepository repository, ILogger<ProductsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(200)] /// what we can expect to be the result of function
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(repository.GetAllProducts());
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to get products: {e}");
                return BadRequest("Bad Request");
            }
        }
    }
}
