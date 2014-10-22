[assembly: WebActivator.PreApplicationStartMethod(typeof(lecture.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(lecture.App_Start.NinjectWebCommon), "Stop")]

namespace lecture.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using lecture.Model.Abstract;
    using lecture.Model.Concrete;
    using lecture.Model.Entities;
    using lecture.BLL;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILog>().To<LogFiles>();

            kernel.Bind<ILessionRecordRepository>().To<LessionRecordRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ITaskByDetailRepository>().To<TaskByDetailRepository>();
            kernel.Bind<ITaskByNameRepository>().To<TaskByNameRepository>();
            kernel.Bind<ITaskByTypeRepository>().To<TaskByTypeRepository>();
            kernel.Bind<ITeacherTypeRepsoitory>().To<TeacherTypeRepository>();
            kernel.Bind<IDepartmentRepository>().To<DepartmentRepository>();
            kernel.Bind<IClassRepository>().To<ClassRepository>();
            kernel.Bind<ICourseRepository>().To<CourseRepository>();
            kernel.Bind<ICourseTeacherRepository>().To<CourseTeacherRepository>();
            kernel.Bind<IMajorRepository>().To<MajorRepsoitory>();
            kernel.Bind<IItemTypeRepository>().To<ItemTypeRepository>();
            kernel.Bind<ITargetRepository>().To<TargetRepository>();

            kernel.Bind<IUserRegister>().To<UserRegister>();
            kernel.Bind<IRecordSystem>().To<RecordSystem>();
            kernel.Bind<ITaskByDetail>().To<TaskByDetail>();
            kernel.Bind<ITaskByName>().To<TaskByName>();
            kernel.Bind<ITaskByType>().To<TaskByType>();
            kernel.Bind<ITeacherType>().To<TeacherType>();
            kernel.Bind<IDepartment>().To<Department>();
            kernel.Bind<IClass>().To<Class>();
            kernel.Bind<ICourse>().To<Course>();
            kernel.Bind<ICourseTeacher>().To<CourseTeacher>();
            kernel.Bind<IMajor>().To<Major>();
            kernel.Bind<ILessionCheckUp>().To<LessionCheckUp>();


        }
    }
}
