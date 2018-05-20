using AutoMapper;
using Entity.Enums;
using SheepCrab.DeliveryService.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SheepCrab.DeliveryService.AutoMapper
{
    public class AccountTypeProfile: Profile
    {
        public AccountTypeProfile()
        {
            CreateMap<AccountType, AccountTypeDto>();
            CreateMap<AccountTypeDto, AccountType>();
        }
    }
}
