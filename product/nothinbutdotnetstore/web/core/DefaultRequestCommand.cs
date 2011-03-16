using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestCriteria criteria;

        public DefaultRequestCommand(RequestCriteria criteria)
        {
            this.criteria = criteria;
        }

        public bool can_handle(Request request)
        {
            return criteria(request);
        }

        public void process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}