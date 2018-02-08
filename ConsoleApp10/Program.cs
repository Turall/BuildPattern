using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            IBuilder builder = new ConcretBuilder();
            Director director = new Director();
            director.Construct(builder);
            builder.GetResult().show();

        }
    }

    class Director
    {
        public void Construct (IBuilder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }

   interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
        Product GetResult();
    }

    class ConcretBuilder : IBuilder
    {
        Product product;
        public ConcretBuilder()
        {
            product = new Product();
        }
        public void BuildPartA()
        {
            product.Add("11");
        }

        public void BuildPartB()
        {
            product.Add("22");
        }

        public void BuildPartC()
        {
            product.Add("33");
        }

        public Product GetResult()
        {
            return product;
        }
    }

    class Product
    {
        List<string> list = new List<string>();

        public void Add(string str)
        {
            list.Add(str);
        }
        public void show ()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item); ;
            }
        }
    }
}
