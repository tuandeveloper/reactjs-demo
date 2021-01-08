using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace Report.Core.Entity
{
    public class EmployeeList
    {
        public EmployeeList()
        {
            Items = InitializeList();
        }

        public EmployeeList(Dictionary<string, string> parameter)
        {
            Items = InitializeList();
            if (parameter != null)
            {
                var personName = parameter["personName"];
                if (!string.IsNullOrWhiteSpace(personName))
                {
                    Items = Items.Where(t => t.PersonName.ToUpper().Contains(personName.ToUpper())).ToList();
                }
            }
        }

        public List<DataItem> Items { get; set; }

        public List<DataItem> InitializeList()
        {
            return new List<DataItem>() {
               new DataItem(1, 101, "Andrew Fuller", "Dr.", "Vice President, Sales"),
               new DataItem(1, 102, "Anne Dodsworth", "Ms.", "Sales Representative"),
               new DataItem(1, 103, "Michael Suyama", "Mr.", "Sales Representative"),
               new DataItem(1, 104, "Jyanet Leverling", "Ms.", "Sales Representative"),
               new DataItem(1, 105, "Elliot Komaroff", "Dr.", "Sales Coordinator"),
               new DataItem(2, 201, "Nancy Davolio", "Ms.", "Sales Representative"),
               new DataItem(2, 202, "Steven Buchanan", "Mr.", "Sales Manager"),
               new DataItem(2, 203, "Laura Callahan", "Ms.", "Sales Coordinator"),
               new DataItem(3, 301, "Frédérique Citeaux", "Mr.", "Sales Coordinator"),
               new DataItem(3, 302, "Laurence Lebihan", "Mr.", "Sales Representative"),
               new DataItem(3, 303, "Elizabeth Lincoln", "Ms.", "Sales Manager"),
               new DataItem(3, 304, "Yang Wang", "Mr.", "Sales Representative"),
               new DataItem(4, 401, "Antonio Moreno", "Mr.", "Sales Representative"),
               new DataItem(4, 402, "Thomas Hardy", "Mr.", "Sales Representative"),
               new DataItem(4, 403, "Christina Berglund", "Ms.", "Sales Manager"),
               new DataItem(5, 501, "Alejandra Camino", "Ms.", "Sales Representative"),
               new DataItem(5, 502, "Matti Karttunen", "Mr.", "Sales Representative"),
               new DataItem(5, 503, "Rita Müller", "Mrs.", "Sales Representative"),
           };
        }
    }
    public class DataItem
    {
        public DataItem(int floor, int office, string personName, string titleOfCourtesy, string title)
        {
            Floor = floor;
            Office = office;
            PersonName = personName;
            TitleOfCourtesy = titleOfCourtesy;
            Title = title;
        }
        public int Floor { get; set; }
        public int Office { get; set; }
        public string PersonName { get; set; }
        public string TitleOfCourtesy { get; set; }
        public string Title { get; set; }
    }
}
