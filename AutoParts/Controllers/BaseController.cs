using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
