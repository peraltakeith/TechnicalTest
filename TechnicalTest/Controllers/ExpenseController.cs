using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Xml;

namespace TechnicalTest.Controllers
{
    public class ExpenseController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string text)
        {
            string sample = @"
Hi Yvaine,
Please create an expense claim for the below. Relevant details are marked up as requested...
<expense>
	<cost_centre>DEV002</cost_centre>
	<total>1024.01</total>
	<payment_method>personal card</payment_method>
</expense>

From: Ivan Castle Sent: Friday, 16 February 2018 10:32 AM
To: Antoine Lloyd <Antoine.Lloyd@example.com>
Subject: test
Hi Antoine,
Please create a reservation at the <vendor>Viaduct Steakhouse</vendor> our
<description>development team's project end celebration dinner</description> on <date>Tuesday
27 April 2017</date>. We expect to arrive around 7.15pm. Approximately 12 people but I'll
confirm exact numbers closer to the day.
Regards,
Ivan
";

            //this should take care of the email problem in the sample text
            var regex = new Regex("<.*@.*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            sample = regex.Replace(sample, "");

            string xml = $"<Root> {sample} </Root>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var xmlFragments = from XmlNode node in doc.FirstChild.ChildNodes
                               where node.NodeType == XmlNodeType.Element
                               select node;

            var sb = new StringBuilder();
            foreach(var fragment in xmlFragments)
            {
                sb.Append(fragment.OuterXml);
            }

            Console.WriteLine(sb.ToString());
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
