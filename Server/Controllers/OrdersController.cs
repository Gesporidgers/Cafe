using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server;

namespace Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly OrderContext _context;
		private readonly MenuContext _menuContext;

		public OrdersController(OrderContext context, MenuContext menuContext)
		{
			_context = context;
			_menuContext = menuContext;
		}

		// GET: api/Orders
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Order>>> Getorders()
		{
			return await _context.orders.ToListAsync();
		}




		// PUT: api/Orders/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpOptions("{id}")]
		public async Task<IActionResult> ChangeStatus(long id, Order.status futureStatus)
		{
			var order = await _context.orders.FindAsync(id);
			if (order != null)
			{
				order.Status = futureStatus;
				await _context.SaveChangesAsync();
			}
			else
			{
				return NotFound();
			}
			return NoContent();
		}

		// POST: api/Orders
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Order>> PostOrder(Order order)
		{
			_context.orders.Add(order);
			await _context.SaveChangesAsync();

			Console.WriteLine(order);

			Console.WriteLine(order.Id);
			foreach (var item in order.Food)
				Console.WriteLine(item);
            //Console.WriteLine(item.Key + " : " + item.Value);

            return order;
		}

		// DELETE: api/Orders/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOrder(long id)
		{
			var order = await _context.orders.FindAsync(id);
			if (order == null)
			{
				return NotFound();
			}

			_context.orders.Remove(order);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<string>> Checkout(long id)
		{
			StringBuilder stringBuilder = new StringBuilder();
			var order = await _context.orders.FindAsync(id);
			if (order != null)
			{

				foreach (var itm in order.Food)
				{
					var fd = _menuContext.menu.FirstOrDefault(e=> (long)e.id == itm);
                    // var fd = _menuContext.menu.FirstOrDefault(e => (long)e.id == itm.Key);

                    stringBuilder.AppendLine($"{fd.Name}.........{fd.Price}\n");
				}
				;
			}
			else
			{
				NotFound();
			}
			return stringBuilder.ToString();
		}

		private bool OrderExists(long id)
		{
			return _context.orders.Any(e => e.Id == id);
		}
	}
}
