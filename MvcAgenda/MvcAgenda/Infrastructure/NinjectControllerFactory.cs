using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using MvcAgenda.Domain.Abstract;
using MvcAgenda.Domain.Entities;
using MvcAgenda.Domain.Concrete;
using MvcAgenda.Infrastructure.Abstract;
using MvcAgenda.Infrastructure.Concrete;

namespace MvcAgenda.Infrastructure
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory() {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType); //base.GetControllerInstance(requestContext, controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IEmailSender>().To<EmailSender>();
            //mock bindings to develop model and ui at the same time
            //Mock<IEventRepository> mevent = new Mock<IEventRepository>();
            //IQueryable<MvcAgenda.Domain.Entities.aevent> events = new List<MvcAgenda.Domain.Entities.aevent> { new MvcAgenda.Domain.Entities.aevent { title = "dentist" }, new MvcAgenda.Domain.Entities.aevent { title = "interview" } }.AsQueryable();
           // mevent.Setup(e => e.Events).Returns(events);
            //ninjectKernel.Bind<IEventRepository>().ToConstant(mevent.Object);

            ninjectKernel.Bind<IEventRepository>().To<EntFEventRepository>();
            ninjectKernel.Bind<IUserRepository>().To<EntFUserRepository>();
            ninjectKernel.Bind<ILocationRepository>().To<EntFLocationRepository>();
            ninjectKernel.Bind<ICommentRepository>().To<EntFCommentRepository>();
          
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }


    }
}
