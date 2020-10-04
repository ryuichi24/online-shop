using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Repositories.AddressRepo;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : RootController<Address, IAddressRepository>
    {
        public AddressController(IAddressRepository repository) : base(repository) { }
    }
}