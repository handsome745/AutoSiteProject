using Autofac;

namespace AutoSiteProject.Dependency
{
    public class AutofacDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<SqlRepository>().As<IRepository>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
