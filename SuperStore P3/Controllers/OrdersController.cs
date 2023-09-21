using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using Repositories;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly OrderRepository _orderRepository;

        public OrdersController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !_orderRepository.OrderExists(id.Value))
            {
                return NotFound();
            }

            var order = await _orderRepository.GetOrderByIdAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            // You can add any necessary view data here if needed.
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.CreateOrderAsync(order);
                return RedirectToAction(nameof(Index));
            }

            // You can add any necessary view data here if needed.
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || !_orderRepository.OrderExists(id.Value))
            {
                return NotFound();
            }

            var order = await _orderRepository.GetOrderByIdAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            // You can add any necessary view data here if needed.
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _orderRepository.UpdateOrderAsync(order);
                return RedirectToAction(nameof(Index));
            }

            // You can add any necessary view data here if needed.
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !_orderRepository.OrderExists(id.Value))
            {
                return NotFound();
            }

            var order = await _orderRepository.GetOrderByIdAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
