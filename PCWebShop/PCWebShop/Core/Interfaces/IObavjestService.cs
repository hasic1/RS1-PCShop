﻿using PCWebShop.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PCWebShop.Core.Interfaces
{
   public  interface IObavjestService
    {
        Task<Message> GetObavjestByUserIdAsMessageAsync(int id, CancellationToken cancellationToken);
        Task<Message> SetObavjestAsDeletedAsync(int obavjestId, CancellationToken cancellationToken);
        Task<Message> GetUnReadObavjestByUserIdAsMessageAsync(int id, CancellationToken cancellationToken);
        Task<Message> SetObavjestAsReadAsMessageAsync(int id, CancellationToken cancellationToken);
        Task CreateBirthdayNotifications();
    }
}
