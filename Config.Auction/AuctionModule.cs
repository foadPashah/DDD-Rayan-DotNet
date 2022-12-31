using Application.Auction.CQRS;
using Application.Auction.Decoratore;
using Application.Contracts.Auction;
using Autofac;
using Framework.CQRS;

namespace Config.Auction
{
    public class AuctionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(OpenAuctionHandler).Assembly)
                .As(type => type.GetInterfaces().Where(interfaceType => interfaceType.IsClosedTypeOf(typeof(ICommandHandler<>))))
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandBus>().As<ICommandBus>().SingleInstance();

            builder.RegisterGenericDecorator(typeof(LoggingCommandHandlerDecoratore<>), typeof(ICommandHandler<>));

            base.Load(builder);
        }
    }
}
