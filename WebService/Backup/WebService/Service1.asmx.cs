using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using LitJson;
using System.Web.Script.Services;
namespace WebService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Name
    {
        public String firstName;
        public String lastName;
    }
    public class Person
    {
        public Name name;
        public int age;
        public List<Name> list;
        public Name[] arr;
    }
    public class Service1 : System.Web.Services.WebService
    {
        Person us = new Person();
        [WebMethod]
        //[ScriptMethod(UseHttpGet = false)]
        public string Test()
        {
            us.name = new Name();
            us.name.firstName = "我是天才";
            us.name.lastName = "Tian";
            us.age = 10089;
            us.list = new List<Name>();
            //us.list[0] = new Name();
            Name na = new Name();
            na.firstName = "黄";
            na.lastName = "Ze";
            us.list.Add(na);
            //us.list[1] = new Name();
            Name na2 = new Name();
            na2.firstName = "黄";
            na2.lastName = "Ze";
            us.list.Add(na2);

            us.arr = new Name[2];
            us.arr[0] = new Name();
            us.arr[0].firstName = "孙";
            us.arr[0].lastName = "Yang";


            us.arr[1] = new Name();
            us.arr[1].firstName = "孙";
            us.arr[1].lastName = "Yang";

            return JsonMapper.ToJson(us);
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}