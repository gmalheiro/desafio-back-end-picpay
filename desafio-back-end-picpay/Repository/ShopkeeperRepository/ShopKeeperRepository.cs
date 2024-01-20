﻿using desafio_back_end_picpay.Data.Context;
using desafio_back_end_picpay.Models;
using desafio_back_end_picpay.Repository.Generic;

namespace desafio_back_end_picpay.Repository.ShopKeeperRepository;

public class ShopkeeperRepository: GenericRepository<ShopKeeper>, IShopKeeperRepository
{
    public ShopkeeperRepository(DatabaseContext context) : base(context)
    {
    }
}
