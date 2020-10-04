using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.US.Common.Controllers
{
    /// <summary>
    /// Base class for all api controllers
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class APIBaseController : ControllerBase
    {
    }
}
