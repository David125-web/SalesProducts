using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesProducts.Api.Responses;
using SalesProducts.Core.DTOs;
using SalesProducts.Core.Entities;
using SalesProducts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SalesProducts.Api.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        /// <summary>
        /// Return all post generators
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetOrders))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<OrderDTo>>))]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<PostDTo>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> GetOrders()
        {
            var orders = _orderService.GetOrders();
            var ordersDtos = _mapper.Map<IEnumerable<OrderDTo>>(orders);
            var response = new ApiResponse<IEnumerable<OrderDTo>>(ordersDtos);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrder(id);
            var orderDto = _mapper.Map<OrderDTo>(order);
            var response = new ApiResponse<OrderDTo>(orderDto);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(OrderDTo orderDTo)
        {
            var order = _mapper.Map<Order>(orderDTo);
            await _orderService.InsertOrder(order);
            var orderDto = _mapper.Map<OrderDTo>(order);

            var response = new ApiResponse<OrderDTo>(orderDto);

            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, OrderDTo orderDTo)
        {
            var order = _mapper.Map<Order>(orderDTo);
            order.Id = id;
            var result = await _orderService.UpdateOrder(order);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
