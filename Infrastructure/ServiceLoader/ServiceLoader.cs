using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Configuration;
using System.Globalization;

namespace Infrastructure
{
    public static class ServiceLoader
    {
        public static void Load()
        {

        }
        private static readonly TransparentProxyInterceptor injector = new TransparentProxyInterceptor();

        public static IUnityContainer Container
        { get; private set; }

        static ServiceLoader()
        {
            try
            {
                UnityConfigurationSection unitySection = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
                if (unitySection == null)
                {
                    throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, "缺少Unity配置部分."));
                }

                Container = new UnityContainer();

                foreach (var item in unitySection.Containers)
                {
                    item.Configure(Container);
                }
                //unitySection.Configure(Container);
                Container.AddNewExtension<Interception>();
            }
            catch (Exception ex){

                throw new ConfigurationErrorsException(ex.ToString());
            }
            //LoadMapper();
        }

        //static void LoadMapper()
        //{
        //    //var typeAdapterFactory = LoadService<ITypeAdapterFactory>();
        //    //TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        //}

        public static T LoadService<T>()
        {
            Container.Configure<Interception>().SetDefaultInterceptorFor(typeof(T), injector);
            return Container.Resolve<T>();
        }

        public static T LoadService<T>(string serviceName)
        {
            Container.Configure<Interception>().SetDefaultInterceptorFor(typeof(T), injector);
            return Container.Resolve<T>(serviceName);
        }
    }
}
