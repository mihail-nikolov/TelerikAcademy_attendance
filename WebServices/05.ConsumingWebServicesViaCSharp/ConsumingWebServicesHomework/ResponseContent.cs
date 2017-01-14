namespace ConsumingWebServicesHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class ResponseContent
    {
        public string Uuid { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Body { get; set; }
    }
}
