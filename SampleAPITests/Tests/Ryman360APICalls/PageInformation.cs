using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPITests.Tests.Ryman360APICalls
{

    public class PageInformation
    { }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class PageRef
    {
        public string oid { get; set; }
        public string pageIdentifier { get; set; }
        public bool isPublished { get; set; }
    }

    public class Child2
    {
        public string name { get; set; }
        public string parentName { get; set; }
        public object[] children { get; set; }
        public PageRef pageRef { get; set; }
    }

    public class Child
    {
        public string name { get; set; }
        public string parentName { get; set; }
        public Child2[] children { get; set; }
        
    }

    public class Root2
    {
        public string name { get; set; }
        public object parentName { get; set; }
        public Child[] children { get; set; }
        public object pageRef { get; set; }
    }

    public class Root
    {
        public Root2 root { get; set; }
    }

}
