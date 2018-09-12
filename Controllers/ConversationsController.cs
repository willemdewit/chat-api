using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using chatApi.Models;
using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using Microsoft.Extensions.Logging;

namespace chatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableRoutingConvention]
    public class ConversationsController : JsonApiController<Conversation>
    {
        private readonly AppDbContext _context;

        public ConversationsController(IJsonApiContext chatApiContext, IResourceService<Conversation> resourceService,
            ILoggerFactory loggerFactory) : base(chatApiContext, resourceService, loggerFactory)
        { }
    }
}