using System;

namespace nothinbutdotnetstore.utility.containers.basic
{
    public class BasicDependencyFactory : DependencyFactory
    {
        Func<object> creation_method;

        public BasicDependencyFactory(Func<object> creation_method)
        {
            this.creation_method = creation_method;
        }

        public object create()
        {
            return creation_method();
        }
    }
}