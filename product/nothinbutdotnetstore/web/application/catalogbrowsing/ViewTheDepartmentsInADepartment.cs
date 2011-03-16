using System;
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheDepartmentsInADepartment  :ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        DepartmentRepository department_repository;

        public ViewTheDepartmentsInADepartment() : this(Stub.with<StubRenderingGateway>(),
                                                         Stub.with<StubDepartmentsRepository>())
        {
        }

        public ViewTheDepartmentsInADepartment(RenderingGateway rendering_gateway,
                                                DepartmentRepository department_repository)
        {
            this.rendering_gateway = rendering_gateway;
            this.department_repository = department_repository;
        }

        public void process(Request request)
        {
            string department_name = request.get_parameters()["department_name"];
            rendering_gateway.render(department_repository.get_the_sub_departments(department_name));
        }
    }
}