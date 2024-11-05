using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
public class UserManagementController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserManagementController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        return View(users);
    }

    // Additional methods for creating, updating, and deleting users
}
