using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewTheModelWithCriteria<ReportModel> : ApplicationBehaviour
    {
        RenderingGateway rendering_gateway;
        RetrieveModel<ReportModel> retrieve_model;
 
        public ViewTheModelWithCriteria(RenderingGateway rendering_gateway,
                                                RetrieveModel<ReportModel> retrieve_model)
        {
            this.rendering_gateway = rendering_gateway;
            this.retrieve_model = retrieve_model;
        }

        public void process(Request request)
        {
            rendering_gateway.render(retrieve_model(request));
        }
    }

    public delegate ReportModel RetrieveModel< ReportModel>(Request request);

}