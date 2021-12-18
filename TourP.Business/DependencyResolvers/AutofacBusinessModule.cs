using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http.Abstractions;
using TourP.Business.Abstract;
using TourP.Business.Concrete;
using TourP.DataAccess.Abstract;
using TourP.DataAccess.Concrete.EntityFramework;

namespace TourP.Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdsManager>().As<IAdsService>();
            builder.RegisterType<AdsDal>().As<IAdsDal>();
            builder.RegisterType<ContentManager>().As<IContentService>();
            builder.RegisterType<ContentDal>().As<IContentDal>();
            builder.RegisterType<EntryManager>().As<IEntryService>();
            builder.RegisterType<EntryDal>().As<IEntryDal>();
            builder.RegisterType<StepManager>().As<IStepService>();
            builder.RegisterType<StepDal>().As<IStepDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();
        }
    }
}
