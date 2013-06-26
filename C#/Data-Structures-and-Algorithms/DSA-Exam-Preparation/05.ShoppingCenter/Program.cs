using System;
using System.Globalization;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace _05.ShoppingCenter
{
    class Program
    {
        const string ADD_COMMAND = "AddProduct";
        const string DELETE_COMMAND = "DeleteProducts";
        const string FINDBYNAME_COMMAND = "FindProductsByName";
        const string FINDBYPRICE_RANGE_COMMAND = "FindProductsByPriceRange";
        const string FINDBYPRODUCER_COMMAND = "FindProductsByProducer";

        static MultiDictionary<string, Product> dataByName = new MultiDictionary<string, Product>(true);
        static MultiDictionary<string, Product> dataByProducer = new MultiDictionary<string, Product>(true);
        static OrderedMultiDictionary<double, Product> dataByPrice = new OrderedMultiDictionary<double, Product>(true);
        //static MultiDictionary<Tuple<string, string>, Product> dataByNameAndProducer = new MultiDictionary<Tuple<string, string>, Product>(true);

        static StringBuilder output = new StringBuilder();

        static void Main()
        {
            var commandCount = int.Parse(Console.ReadLine());

            for (var i = 0; i < commandCount; i++)
            {
                var line = Console.ReadLine();
                ProccessCommand(line);
            }

            Console.WriteLine(output);
        }

        static void ProccessCommand(string line)
        {
            string[] commandParts = line.Split(new char[] { ' ' }, 2);

            if (commandParts[0] == ADD_COMMAND)
            //if (line.Substring(0,line.IndexOf(' ')) == "AddProduct" )
            {
                var splittedArgs = commandParts[1].Split(';');
                var productName = splittedArgs[0];

                var price = Double.Parse(splittedArgs[1], CultureInfo.InvariantCulture);
                var producer = splittedArgs[2];

                var product = new Product(productName, price, producer);

                dataByName.Add(productName, product);
                dataByProducer.Add(producer, product);
                dataByPrice.Add(price, product);
                //dataByNameAndProducer.Add(new Tuple<string, string>(productName, producer), product);

                output.AppendLine("Product added");
            }
            else if (commandParts[0] == DELETE_COMMAND)
            {

                var args = commandParts[1].Split(';');

                //delete by producer 
                if (args.Count() == 1)
                {
                    var producerToRemove = args[0];
                    var foundProducts = dataByProducer[producerToRemove];
                    var deletedItemsCount = foundProducts.Count;
                    if (foundProducts.Count <= 0)
                    {
                        output.AppendLine("No products found");
                        return;
                    }

                    foreach (var item in foundProducts)
                    {
                        dataByName.Remove(item.Name);
                        dataByPrice.Remove(item.Price, item);
                        //dataByNameAndProducer.Remove(new Tuple<string,string>(item.Name,item.Producer), item);
                    }

                    dataByProducer.Remove(producerToRemove);

                    output.AppendLine(deletedItemsCount + " products deleted");
                }
                else
                {
                    // delete by producer and name 
                    var producertoDelete = args[1];
                    var itemToLower = args[0];
                    var foundProducts = dataByName[itemToLower].Where(x => x.Producer == producertoDelete);
                    // var foundProducts = dataByNameAndProducer[new Tuple<string, string>(itemToLower, producertoDelete)];
                    var deletedItemsCount = foundProducts.Count();

                    if (foundProducts.Count() <= 0)
                    {
                        output.AppendLine("No products found");
                        return;
                    }

                    foreach (var item in foundProducts.ToList())
                    {
                        dataByName.Remove(item.Name);
                        dataByPrice.Remove(item.Price, item);
                        dataByProducer.Remove(item.Producer, item);
                        //dataByNameAndProducer.Remove(new Tuple<string, string>(item.Name, item.Producer), item);
                    }


                    output.AppendLine(deletedItemsCount + " products deleted");
                }
            }
            else if (commandParts[0] == FINDBYNAME_COMMAND)
            //else if (line.Substring(0, line.IndexOf(' ')) == "FindProductsByName")
            {
                var name = commandParts[1];


                var foundItems = dataByName[name].OrderBy(x => x.Name).ThenBy(x => x.Producer);

                if (foundItems.Count() <= 0)
                {
                    output.AppendLine("No products found");
                    return;
                }

                foreach (var item in foundItems)
                {
                    output.AppendLine(item.ToString());
                }

            }
            else if (commandParts[0] == FINDBYPRICE_RANGE_COMMAND)
            {

                var args = commandParts[1].Split(';');

                var rangeFrom = double.Parse(args[0], CultureInfo.InvariantCulture);
                var rangeTo = double.Parse(args[1], CultureInfo.InvariantCulture);

                var foundEvents =
                from item in dataByPrice.Range(rangeFrom, true, rangeTo, true).Values
                select item;

                var h = foundEvents.OrderBy(x => x.Name).ThenBy(x => x.Producer);
                if (foundEvents.Count() <= 0)
                {
                    output.AppendLine("No products found");
                    return;
                }

                foreach (var item in h)
                {
                    output.AppendLine(item.ToString());
                }

            }
            else if (commandParts[0] == FINDBYPRODUCER_COMMAND)
            {
                var producerName = commandParts[1];


                var foundItems = dataByProducer[producerName].OrderBy(x => x.Name).ThenBy(x => x.Producer);

                if (foundItems.Count() <= 0)
                {
                    output.AppendLine("No products found");
                    return;
                }

                foreach (var item in foundItems)
                {
                    output.AppendLine(item.ToString());
                }
            }

        }


    }
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Producer { get; set; }

        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (string.IsNullOrWhiteSpace(this.Name) || string.IsNullOrWhiteSpace(this.Producer))
            {
                return result.ToString();
            }

            result.Append('{');

            result.Append(this.Name);
            result.Append(';');

            result.Append(this.Producer);
            result.Append(';');

            result.AppendFormat("{0:0.00}", this.Price);

            result.Append('}');
            return result.ToString();
        }

        public int CompareTo(Product other)
        {
            if (this.Name.CompareTo(other.Name) < 0)
            {
                return -1;
            }
            else if (this.Name.CompareTo(other.Name) > 0)
            {
                return 1;
            }
            else
            {
                return this.Producer.CompareTo(other.Producer);
            }
        }
    }
}
