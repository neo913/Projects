using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            //Mapper.CreateMap<>();
            
            //
            // Card
            Mapper.CreateMap<Models.Card, Controllers.CardBase>();
            Mapper.CreateMap<Models.Card, Controllers.CardWithDetails>();
            Mapper.CreateMap<Controllers.CardAddForm, Models.Card>().ReverseMap();
            Mapper.CreateMap<Controllers.CardAdd, Models.Card>().ReverseMap();
            Mapper.CreateMap<Controllers.CardBase, Controllers.CardWithDetails>();

            //
            // Customer
            Mapper.CreateMap<Models.Customer, Controllers.CustomerBase>();
            Mapper.CreateMap<Models.Customer, Controllers.CustomerWithDetails>();
            Mapper.CreateMap<Controllers.CustomerAdd, Models.Customer>();
            Mapper.CreateMap<Controllers.CustomerAddForm, Models.Customer>();
            Mapper.CreateMap<Controllers.CustomerAddForm, Controllers.CustomerAdd>();
            Mapper.CreateMap<Controllers.CustomerBase, Controllers.CustomerEditForm>();
            Mapper.CreateMap<Controllers.CustomerWithDetails, Controllers.CustomerEditForm>();
            Mapper.CreateMap<Controllers.CustomerEditForm, Controllers.CustomerEdit>().ReverseMap();


            //
            // Account

            Mapper.CreateMap<Models.Account, Controllers.AccountBase>();
            Mapper.CreateMap<Models.Account, Controllers.AccountWithDetails>();
            Mapper.CreateMap<Models.Account, Controllers.AccountEditForm>();
            Mapper.CreateMap<Controllers.AccountAdd, Models.Account>();
            Mapper.CreateMap<Controllers.AccountAddForm, Models.Account>();
            Mapper.CreateMap<Controllers.AccountAddForm, Controllers.AccountAdd>();
            Mapper.CreateMap<Controllers.AccountBase, Controllers.AccountEditForm>();
            Mapper.CreateMap<Controllers.AccountWithDetails, Controllers.AccountEditForm>();
            Mapper.CreateMap<Controllers.AccountEditForm, Controllers.AccountEdit>().ReverseMap();

            //
            // Record
            Mapper.CreateMap<Models.Record, Controllers.RecordBase>();
            Mapper.CreateMap<Models.Record, Controllers.RecordWithDetails>();
            Mapper.CreateMap<Controllers.RecordAdd, Models.Record>();
            Mapper.CreateMap<Controllers.RecordAdd, Controllers.RecordBase>();
            Mapper.CreateMap<Controllers.RecordAddForm, Models.Record>();
            Mapper.CreateMap<Controllers.RecordAddForm, Controllers.RecordAdd>();


#pragma warning disable CS0618

            Mapper.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();
#pragma warning restore CS0618
        }
    }
}