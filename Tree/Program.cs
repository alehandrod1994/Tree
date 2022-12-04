using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>();
            tree.Add("привет", 50);
            tree.Add("мир", 100);
            tree.Add("приз", 200);
            tree.Add("мирный", 50);
            tree.Add("подарок", 100);
            tree.Add("проект", 200);
            tree.Add("прапорщик", 100);
            tree.Add("правый", 200);
            tree.Add("год", 50);
            tree.Add("герой", 100);
            tree.Add("красота", 300);
            tree.Add("голубь", 200);
            tree.Add("прокрастинация", 1000);

            tree.Remove("правый");
            tree.Remove("мир");

            Search(tree, "привет");
            Search(tree, "мир");
            Search(tree, "облако");
            Search(tree, "мирный");
            Search(tree, "прокрастинация");
            Search(tree, "год");

            Console.ReadLine();
        }

        private static void Search(Tree<int> tree, string word)
        {
            if (tree.TrySearch(word, out int value))
            {
                Console.WriteLine(word + " " + value);
            }
            else
            {
                Console.WriteLine("Не найдено " + word);
            }
        }
    }
}
