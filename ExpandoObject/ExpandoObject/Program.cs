
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Dynamic;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Xml;

namespace ExpandoObjectExample
{
    class Program
    {
        static void Main(string[] args)
        {

            XElement e = ResponseToXElement( XElement.Load(@"C:\Lubna\Employees_Workday.xml").ToString());
            ExpandoObject x = new ExpandoObject();
            Parse(x, e.Elements().First());


            var ListOfEmployees = (IEnumerable<XElement>)e.Elements();

            foreach (var employee in ListOfEmployees)
            {
                Parse(x, employee);
            }


            try
            {
                ExpandoObject workerRoot = x?.TryGetProperty("Worker");
                ExpandoObject workerData = workerRoot?.TryGetProperty("Worker_Data");
                ExpandoObject personalData = workerData?.TryGetProperty("Personal_Data");
                ExpandoObject contactData = personalData?.TryGetProperty("Contact_Data");
                ExpandoObject legalNameData = personalData?.TryGetProperty("Name_Data")?.TryGetProperty("Legal_Name_Data")
                                        ?.TryGetProperty("Name_Detail_Data");
                ExpandoObject prefferedNameData = personalData?.TryGetProperty("Name_Data")?.TryGetProperty("Preferred_Name_Data")
                    ?.TryGetProperty("Name_Detail_Data");
                ExpandoObject phone = contactData?.TryGetProperty("Phone_Data");
                ExpandoObject email = contactData?.TryGetProperty("Email_Address_Data");

                var id = GetValueForProperty(workerData?.TryGetProperty("Worker_ID"), "Worker_ID"); 
                var userName = GetValueForProperty(workerData?.TryGetProperty("User_ID"), "User_ID");
                var firstName = GetValueForProperty(legalNameData?.TryGetProperty("First_Name"), "First_Name");
                var lastName = GetValueForProperty(legalNameData?.TryGetProperty("Last_Name"), "Last_Name");
                var formattedName = GetValueForProperty(prefferedNameData?.TryGetProperty("Formatted_Name"), "Formatted_Name");
                var emailAdd = GetValueForProperty(email?.TryGetProperty("Email_Address"), "Email_Address");
                var workPhone = GetValueForProperty(phone?.TryGetProperty("Phone_Number"), "Phone_Number");

                dynamic obj = new
                {
                   // Schemas = new[] { WorkdaySchemas.Employee },

                    Id = id,
                    UserName = userName,
                    Name = new
                    {
                        GivenName = firstName,
                        FamilyName = lastName,
                        Formatted = formattedName,

                    },
                    DisplayName = workerRoot?.TryGetProperty("Worker_Descriptor"),
                    Emails = new[]
                        {
                           new
                            {
                                Value = emailAdd,
                                Type = "work",
                                Primary = "true",
                            },
                },

                    PhoneNumbers = new[]
                        {
                    new
                    {
                        businessPhone = workPhone,
                        Type =  "work",
                    },
                },
                    userId = userName,
                   // sourceSystem = Constants.SourceSystem,
                };
            }
            catch (Exception ex)
            {

                //return null;
            }

            Console.Read();

        }

        public static object GetValueForProperty(ExpandoObject obj,string propName)
        {
            if (obj != null)
            {
               return  ((IDictionary<string, Object>)obj)[propName];

            }
            else
            {
                return string.Empty;
            }
        }

        public static void Parse(dynamic parent, XElement node)
        {
            if (node != null && node.HasElements)
            {
                if (node.Elements(node.Elements().First().Name.LocalName).Count() > 1)
                {
                    //list
                    var item = new ExpandoObject();
                    var list = new List<dynamic>();
                    foreach (var element in node.Elements())
                    {
                        Parse(list, element);
                    }

                    AddProperty(item, node.Elements().First().Name.LocalName, list);
                    AddProperty(parent, node.Name.ToString(), item);
                }
                else
                {
                    var item = new ExpandoObject();

                    foreach (var attribute in node.Attributes())
                    {
                        AddProperty(item, attribute.Name.ToString(), attribute.Value.Trim());
                    }

                    //element
                    foreach (var element in node.Elements())
                    {
                        Parse(item, element);
                    }

                    AddProperty(parent, node.Name.ToString(), item);
                }
            }
            else
            {
                AddProperty(parent, node.Name.ToString(), node.Value.Trim());
            }

            //return parent;
        }

        public static void AddProperty(dynamic parent, string name, object value)
        {
            if (parent is List<dynamic>)
            {
                (parent as List<dynamic>).Add(value);
            }
            else
            {
                (parent as IDictionary<String, object>)[name] = value;
            }
        }

        public static XElement removeNameSpace(XElement root)
        {
            var elementName = root != null ? root.Name.LocalName : string.Empty;
            object content = string.Empty;

            if (root.HasElements)
                content = root.Elements().Select(el => removeNameSpace(el));
            else if (root != null)
                content = (object) root.Value;

            var newElement =  new XElement(elementName,content);

            if (root.HasAttributes)
            {
                var attributes = (IEnumerable<XAttribute>)root.Attributes();
                foreach (var attr in attributes)
                {
                    newElement.Add(new XAttribute(attr.Name.LocalName, attr.Value));

                }

            }

            return newElement;
        }

        //Core recursion function
        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }

        public static string RemoveAllNamespaces(string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return xmlDocumentWithoutNs.ToString();
        }

        public static XElement ResponseToXElement(string response)
        {
            var formated = Regex.Replace(response, "&(?!(amp|apos|quot|lt|gt);)", "&amp;");
            XElement element = XElement.Parse(formated);
            element = removeNameSpace(element);
            //element = RemoveAllNamespaces(element);

            element = element.Descendants("Response_Data").Any() ? element.Descendants("Response_Data").FirstOrDefault() : null;
            return element;

        }

    }

   


    public static class ExpandoExtesnsion
    {
        public static ExpandoObject TryGetProperty(this ExpandoObject ob,string propertyName)
        {
            
            if (((IDictionary<string, Object>)ob).ContainsKey(propertyName))
            {
                Type type = ((IDictionary<string, Object>) ob)[propertyName].GetType();
                if(type.Name == "ExpandoObject")
                return (ExpandoObject)((IDictionary<string, Object>) ob)[propertyName];
                else
                {
                    var obj = new ExpandoObject();
                    AddProperty(obj, propertyName, ((IDictionary<string, Object>)ob)[propertyName]);
                    return obj;
                }
            }
            else
            {
                return null;

            }
          
        }

        public static void AddProperty(dynamic parent, string name, object value)
        {
            if (parent is List<dynamic>)
            {
                (parent as List<dynamic>).Add(value);
            }
            else
            {
                (parent as IDictionary<String, object>)[name] = value;
            }
        }

    }
}
