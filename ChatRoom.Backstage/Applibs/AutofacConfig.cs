
namespace ChatRoom.Backstage.Applibs
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using ChatRoom.Domain.Model;
    using ChatRoom.Domain.Model.Process;
   

    internal static class AutofacConfig
    {
        private static IContainer container;

        public static IContainer Container
        {
            get
            {
                if (container == null)
                {
                    Register();
                }

                return container;
            }
        }

        public static void Register()
        {
            var builder = new ContainerBuilder();
            var asm = Assembly.GetExecutingAssembly();

            // secondProcess
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<IBackStageProcess>())
                .Keyed<IBackStageProcess>(p => (BackStageProcessType)Enum.Parse(typeof(BackStageProcessType), p.Name.Replace("BackStageProcess", string.Empty), true))
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            // console wrapper
            builder.RegisterType<ConsoleWrapper>()
                .As<IConsoleWrapper>()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            builder.RegisterType<KeyboardReader>()
               .As<IKeyboardReader>()
               .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
               .SingleInstance();

            // service
            builder.RegisterAssemblyTypes(Assembly.Load("ChatRoom.Domain"))
                .WithParameter("serviceUri", ConfigHelper.ServiceUrl)
                .WithParameter("timeout", 5)
                .Where(t => t.Namespace == "ChatRoom.Domain.Service")
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == $"I{t.Name}"))
                .SingleInstance();

            container = builder.Build();
        }
    }
}
