using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CleanArchitecture.US.Common.Extensions;

namespace CleanArchitecture.US.Common.Middleware
{
    /// <summary>
    /// TokenValidatorMiddleware is used to parse token values before requested controller has been invoked.
    /// </summary>
    public class TokenValidatorMiddleware : BaseMiddleware
    {
        #region Properties

        public object Request { get; private set; }
        public const string ApplicationJsonDataType = "application/json";
       

        #endregion
        #region Constructor
        /// <summary>
        /// TokenValidatorMiddleware initializes class object.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        public TokenValidatorMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<TokenValidatorMiddleware> logger) : base(next, configuration, logger)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Invoke method is called when middleware has been called.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="headerValue"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            var authorizationHeader = context.Request.Headers["Authorization"];
           

            if (authorizationHeader.Count != 0)
            {
                int userId = 0;
                userId = this.GetUserIdFromToken(authorizationHeader[0]);
                var request = context.Request;

                if (userId != 0)
                {
                    context.Items["UserID"] = userId.ToString();
                }
            }
            await this.Next(context);
        }

        /// <summary>
        /// GetUserIdFromToken returns the User Id from the token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private int GetUserIdFromToken(string token)
        {
            var userId = string.Empty;

            try
            {

                token = token.Replace("bearer", "").Replace("Bearer", "").Replace(" ", "");

                if (!token.IsValidJWT())
                    return 0;

                var decodedToken = new JwtSecurityToken(token);

                userId = decodedToken.Claims.FirstOrDefault(claim => claim.Type == Constant.UserId).Value;
            }
            catch (Exception ex)
            {
                base.Logger?.LogError(ex, "Method: TokenValidatorMiddleware.GetUserIdFromToken - " + "Exception Message: " + ex.Message);
                return 0;
            }
            return Convert.ToInt32(userId);
        }

        #endregion
    }
}