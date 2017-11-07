
using JBC.FacebookStuff;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JBC
{
    public interface IFacebookService
    {
        Task<Account> GetAccountAsync(string accessToken);
    }

    public class FacebookService : IFacebookService
    {
        private readonly FacebookStuff.IFacebookClient _facebookClient;

        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public async Task<Account> GetAccountAsync(string accessToken)
        {
            var result = await _facebookClient.GetAsync<dynamic>(
                accessToken, "me", "fields=id, name");

            if (result == null)
            {
                return new Account();
            }

            var account = new Account
            {
                Id = result.id,
                Name = result.name
            };

            return account;
        }
    }
}