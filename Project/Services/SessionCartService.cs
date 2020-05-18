using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Project.Helpers;
using Project.Models;
using System;

namespace Project.Services
{
    public class SessionCartService : CartService
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        public static CartService GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            SessionCartService sessionCart = session?.GetJson<SessionCartService>("Cart") ?? new SessionCartService();

            sessionCart.Session = session;

            return sessionCart;
        }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
