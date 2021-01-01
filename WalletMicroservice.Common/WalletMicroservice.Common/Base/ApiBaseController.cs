using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WalletMicroservice.Common._base
{
    [Route("api/[controller]")]
    public class ApiBaseController<T> : ControllerBase
    {
        protected IServiceProvider provider;
        private readonly ILogger<T> _logger;


        public ApiBaseController(IServiceProvider provider, ILogger<T> logger)
        {
            this.provider = provider;
            _logger = logger;
        }

        /// <summary>
        /// Base API Controller
        /// </summary>


        /// <summary>
        /// Get User Profile
        /// </summary>
        /// <returns></returns>
        protected object GetProfile()
        {
            var profile = new UserModel();

            var claims = User.Identity as ClaimsIdentity;
            var phoneNumberClaim = claims.FindFirst("phoneNumber");
            profile.UserName = string.Empty;
            if (phoneNumberClaim != null)
            {
                profile.PhoneNumber = phoneNumberClaim.Value;
            }
            var userTypeClaim = claims.FindFirst("userType");
            profile.UserTypeId = 0;
            if (userTypeClaim != null)
            {
                profile.UserTypeId = (UserTypeEnum)(int.Parse(userTypeClaim.Value));
            }
            var clientClaim = claims.FindFirst("client_id");
            profile.Client = string.Empty;
            if (clientClaim != null)
            {
                profile.Client = clientClaim.Value;
            }
            var userName = claims.FindFirst("userName");
            if (userName != null)
            {
                profile.UserName = userName.Value;
            }
            var idClaim = claims.FindFirst("sub");
            if (idClaim != null)
            {
                profile.Id = idClaim.Value;
            }

            return profile;
        }

        /// <summary>
        /// Get user name
        /// </summary>
        /// <returns></returns>
        protected string GetUsername()
        {
            return GetProfile().UserName;
        }

        /// <summary>
        /// Get usrname of the user or client
        /// </summary>
        /// <returns></returns>
        protected string GetUsernameOrClient()
        {
            var user = GetProfile();
            return !string.IsNullOrWhiteSpace(user.UserName) ? user.UserName : user.Client;
        }

        protected void LogError(Exception ex, string controller, string method)
        {
            _logger.LogError(ex, $"Error from Controler: {controller}, Action Method: {method}");
        }

    }
}
