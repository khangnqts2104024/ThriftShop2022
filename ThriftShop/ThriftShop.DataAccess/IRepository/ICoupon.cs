﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftShop.DataAccess.Repository.IRepository.GenericInterface;
using ThriftShop.Models;

namespace ThriftShop.DataAccess.IRepository
{
    public interface ICoupon : IRepository<Coupon>
    {
        Task<Coupon> Update(Coupon obj);
    }
}