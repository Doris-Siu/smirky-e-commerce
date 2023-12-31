﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Tangy_Business.Repository.IRepository;
using Tangy_Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TangyWeb_API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailSender _emailSender;

        public OrderController(IOrderRepository orderRepository, IEmailSender emailSender)
        {
            _orderRepository = orderRepository;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderRepository.GetAll());
        }

        [HttpGet("{orderHeaderId}")]
        public async Task<IActionResult> Get(int? orderHeaderId)
        {
            if (orderHeaderId == null || orderHeaderId == 0)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var orderHeader = await _orderRepository.Get(orderHeaderId.Value);
            if (orderHeader == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(orderHeader);
        }


        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create([FromBody] StripePaymentDTO paymentDTO)
        {
            paymentDTO.Order.OrderHeader.OrderDate = DateTime.UtcNow;
            var result = await _orderRepository.Create(paymentDTO.Order);
            return Ok(result);
        }


        [HttpPost]
        [ActionName("paymentsuccessful")]
        public async Task<IActionResult> PaymentSuccessful([FromBody] OrderHeaderDTO orderHeaderDTO)
        {
            try
            {
                var service = new SessionService();
                var sessionDetails = service.Get(orderHeaderDTO.SessionId);
                if (sessionDetails.PaymentStatus == "paid")
                {
                    var result = await _orderRepository.MarkPaymentSuccessful(orderHeaderDTO.Id);

                    await _emailSender.SendEmailAsync(orderHeaderDTO.Email, "SMirkY Order Confirmation",
                        "New Order has been created :" + orderHeaderDTO.Id);


                    if (result == null)
                    {
                        return BadRequest(new ErrorModelDTO()
                        {
                            ErrorMessage = "Can not mark payment as successful"
                        });
                    }
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
            return BadRequest();

        }
    }
}

