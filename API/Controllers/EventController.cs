namespace API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Business.Services.Interfaces;

    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        [Route("subscribe/{email}")]
        public async Task<ActionResult> Subscribe(string email)
        {
            await _eventService.SubscribeAsync(email);
            return Ok();
        }
    }
}