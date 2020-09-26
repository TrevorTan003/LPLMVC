using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LPLMVC.Areas.Identity.Data;
using LPLMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LPLMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<LPLMVCUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
            UserManager<LPLMVCUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserClaims(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            // UserManager service GetClaimsAsync method gets all the current claims of the user
            var existingUserClaims = await userManager.GetClaimsAsync(user);

            var model = new UserClaimsModel
            {
                UserId = userId
            };

            // Loop through each claim we have in our application
            foreach (Claim claim in ClaimsStore.AllClaims)
            {
                UsersClaims userClaim = new UsersClaims
                {
                    ClaimType = claim.Type
                };

                // If the user has the claim, set IsSelected property to true, so the checkbox
                // next to the claim is checked on the UI
                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }

                model.Claims.Add(userClaim);
            }

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> ManageUserClaims(UserClaimsModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.UserId} cannot be found";
                return View("NotFound");
            }

            // Get all the user existing claims and delete them
            var claims = await userManager.GetClaimsAsync(user);
            var result = await userManager.RemoveClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(model);
            }

            // Add all the claims that are selected on the UI
            result = await userManager.AddClaimsAsync(user,
                model.Claims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = model.UserId });

        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var model = new List<UsersRolesModel>();

            foreach (var role in roleManager.Roles)
            {
                var userRolesViewModel = new UsersRolesModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>
            ManageUserRoles(List<UsersRolesModel> model, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = userId });
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessaage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            //Returns us the list of user claims and roles
            var userClaims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);

            var model = new EditUserModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessaage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View("ListUsers");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View("ListRoles");
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role With Id = {id} cannot be found";
                return View("Error");
            }

            var model = new EditRoleModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }

            else
            {
                role.Name = model.RoleName;

                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found.";
                return View("NotFound");
            }

            var model = new List<RolesUsersModel>();

            foreach(var user in userManager.Users)
            {
                var userRoleModel = new RolesUsersModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleModel.IsSelected = true;
                }

                else
                {
                    userRoleModel.IsSelected = false;
                }

                model.Add(userRoleModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<RolesUsersModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!(model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name))))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }

                    else
                    {
                        return RedirectToAction("EditRole", new {Id = roleId});
                    }
                }
            }
            return RedirectToAction("EditRole", new { Id= roleId });
        }
    }
}
