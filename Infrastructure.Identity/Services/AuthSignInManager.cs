﻿using Application.Contracts.Identity;
using Application.DTOs.Identity;
using Application.Enums;
using Application.Exceptions;
using Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Services
{
    internal class AuthSignInManager : IAuthSignInManager
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthSignInManager(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<AuthSignInResult> SignIn(SignInRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new NotFoundException();
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RemeberMe, request.LockOutOnFailure);

            return Enum.Parse<AuthSignInResult>(result.ToString(), ignoreCase: true);
        }

        public async Task SignOut(CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
        }
    }
}