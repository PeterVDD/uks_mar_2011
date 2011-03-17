using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using Machine.Specifications;
using developwithpassion.specifications.rhino;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class ViewTheModelWithCriteriaSpecs
    {
        public abstract class concern : Observes<ApplicationBehaviour,
                                            ViewTheDepartmentsInADepartment>
        {
        }

        [Subject(typeof(ViewTheStoreCatalogWithCriteria))]
        public class when_run : concern
        {
            Establish e = () =>
            {
                request = an<Request>();
                rendering_gateway = the_dependency<RenderingGateway>();
                retrieve_model = the_dependency<RetrieveModel<MyReportModel>>();

                the_list_of_reportmodels = new List<MyReportModel> { new MyReportModel() };
                input_model = new MyInputModel();
            };

            Because b = () =>
                sut.process(request);

            It should_retrieve_the_report_model_through_the_delegate = () =>
            {
                retrieve_model.received(x => x(request));
            };

            It should_tell_the_rendering_gateway_to_display_the_sub_departments = () =>
                rendering_gateway.received(x => x.render(the_list_of_reportmodels));

            static Request request;
            static IEnumerable<MyReportModel> the_list_of_reportmodels;
            static RenderingGateway rendering_gateway;
            static MyInputModel input_model;
            static RetrieveModel<MyReportModel> retrieve_model;
        }

        class MyReportModel {}
        class MyInputModel {}
    }
}