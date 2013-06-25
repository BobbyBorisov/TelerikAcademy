using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace ShoppingCenter
{
    class Program
    {
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
            if(line.StartsWith("AddProduct",StringComparison.Ordinal))
            //if (line.Substring(0,line.IndexOf(' ')) == "AddProduct" )
            {
                line = line.Substring(11);
                
                
                var splittedArgs = line.Split(';');
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
            else if (line.StartsWith("DeleteProducts", StringComparison.Ordinal))
            //else if (line.Substring(0, line.IndexOf(' ')) == "DeleteProducts")
            {
                line = line.Substring(15);
                var args = line.Split(';');

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
            else if (line.StartsWith("FindProductsByName", StringComparison.Ordinal))
            //else if (line.Substring(0, line.IndexOf(' ')) == "FindProductsByName")
            {
                var name = line.Substring(19);
                

                var foundItems = dataByName[name].OrderBy(x=>x.Name).ThenBy(x=>x.Producer);

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
            else if (line.StartsWith("FindProductsByPriceRange", StringComparison.Ordinal))
            //else if (line.Substring(0, line.IndexOf(' ')) == "FindProductsByPriceRange")
            {
                line = line.Substring(25);
                var args = line.Split(';');
                var rangeFrom = double.Parse(args[0], CultureInfo.InvariantCulture);
                var rangeTo = double.Parse(args[1], CultureInfo.InvariantCulture);
                
                var foundEvents =
                from item in dataByPrice.Range(rangeFrom, true, rangeTo, true).Values
                select item;

                var h = foundEvents.OrderBy(x => x.Name).ThenBy(x => x.Producer);
                if (foundEvents.Count()<=0) 
                {
                    output.AppendLine("No products found");
                    return;
                }

                foreach (var item in h)
                {
                    output.AppendLine(item.ToString());
                }
                
            }
            //else if (line.StartsWith("FindProductsByProducer", StringComparison.Ordinal))
            else if (line.Substring(0, line.IndexOf(' ')) == "FindProductsByProducer")
            {
                var producerName = line.Substring(23);


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
            //return this.Name.CompareTo(other.Name);
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
