using System;
using System.Collections.Generic;
using System.Linq;

using Ninject;

using TDS.Business.Services.Interface;
using TDS.DataAccess.EntityModels;

namespace TDS.Business.Services.Implementation
{
    public class CartService : BaseService<CartEntity>, ICartService
    {
        public CartService(IKernel kernel)
            : base(kernel)
        {
        }

        public CartEntity GetOrCreate(string identity)
        {
            CartEntity cart = ServiceRepo.GetBy(e => e.UserIdentity.Equals(identity)).FirstOrDefault();
            
            if (cart == null)
            {
                CartEntity entity = new CartEntity
                {
                    UserIdentity = identity,
                    UpdateDate = DateTime.Now,
                    Deliveries = new List<DeliveryEntity>()
                };
                
                Create(entity);

                cart = ServiceRepo.GetBy(e => e.UserIdentity.Equals(identity)).FirstOrDefault();
            }

            return cart;
        }

        public void AddDelivery(string identity, DeliveryEntity delivery)
        {
            CartEntity cart = GetOrCreate(identity);

            cart.Deliveries.Add(delivery);

            UnitOfWork.SaveChanges();
        }

        public void ClearCart(string identity)
        {
            CartEntity cart = GetOrCreate(identity);

            cart.Deliveries.Clear();

            UnitOfWork.SaveChanges();
        }
    }
}