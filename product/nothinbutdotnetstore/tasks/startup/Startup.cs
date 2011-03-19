using System;
using System.Collections.Generic;
using System.Reflection;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.basic;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        static Dictionary<Type, DependencyFactory> all_factories = new Dictionary<Type, DependencyFactory>();
        static BasicDependencyContainer current_container;

        public static void run()
        {
            initialize_core_components();
            initialize_everything_else();
        }

        static void initialize_everything_else()
        {
            register_factory<FrontController, DefaultFrontController>();
            register_factory<CommandRegistry, DefaultCommandRegistry>();
            register_factory<IEnumerable<RequestCommand>, StubSetOfCommands>();
        }

        static ConstructorSelection current_strategy()
        {
            return new GreedyConstructorParameterStrategy().apply_to;
        }

        static void register_factory<RegisteredType, ConcreteType>()
        {
            all_factories.Add(typeof(RegisteredType),
                              new AutomaticDependencyFactory(current_strategy(), typeof(ConcreteType), current_container));
        }

        static void initialize_core_components()
        {
            current_container = new BasicDependencyContainer(new DefaultDependencyFactories(all_factories, missing_factory));
            Container.active_resolver = () => current_container;
        }

        static DependencyFactory missing_factory(Type type_that_has_no_factory)
        {
            throw new NotImplementedException(string.Format("The type {0} has no factory", type_that_has_no_factory.Name));
        }
    }
}