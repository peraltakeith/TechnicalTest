using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Xml;
using TechnicalTest.Helpers;
using TechnicalTest.Models;

namespace TechnicalTest.Controllers
{
    public class ExpenseController : ApiController
    {
        private Expense _expense;
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
        public Expense Post([FromBody] string text)
        {
            var regex = new Regex("<.*@.*>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            text = regex.Replace(text, "");

            string xml = $"<Root> {text} </Root>";

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
            }

            catch(Exception e)
            {
                throw new HttpException(400, e.Message);
            }
            
            var xmlFragments = from XmlNode node in doc.FirstChild.ChildNodes
                               where node.NodeType == XmlNodeType.Element
                               select node;

            var sb = new StringBuilder();
            foreach(var fragment in xmlFragments)
            {
                sb.Append(fragment.OuterXml);
            }

            //need to re-add the root element to the string to avoid problems deserializing the xml
            var newXML = $"<Root> {sb} </Root>";
            _expense = DeserializationHelper.DeserializeXML<Expense>(newXML);

            if(_expense.Total == null)
            {
                throw new HttpException(400, "Bad Request");
            }

            _expense.GST = decimal.Round(Convert.ToDecimal(GSTHelper.GSTCalculator(_expense.Total)), 
                2, MidpointRounding.AwayFromZero);
            _expense.TotalExcludingGST = decimal.Round(Convert.ToDecimal(_expense.Total - _expense.GST),
                2, MidpointRounding.AwayFromZero);

            return _expense;
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
