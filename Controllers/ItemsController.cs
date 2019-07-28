using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using todo;
using todo.Models;

namespace quickstartcore.Controllers
{
    [Produces("application/json")]
    [Route("api/Items")]
    public class ItemsController : Controller
    {
        private readonly IDocumentDBRepository<Item> Respository;
        public ItemsController(IDocumentDBRepository<Item> Respository)
        {
            this.Respository = Respository;
        }

        // GET: api/Items
        [HttpGet]
        [EnableQuery()]
        public async Task<IEnumerable<Item>> Get()
        {
            return await Respository.GetItemsAsync(d => !d.Completed);
        }
    }
}
