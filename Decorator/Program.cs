using System;

namespace DecoratorPatternExample
{
    // Component
    public abstract class ChristmasTree
    {
        public abstract string GetDescription();

        // Can be extended later by the garland
        public virtual void LightUp()
        {
            Console.WriteLine("The tree stands in the dark, no lights.");
        }
    }

    // ConcreteComponent - a plain tree
    public class BaseChristmasTree : ChristmasTree
    {
        public override string GetDescription()
        {
            return "Green Christmas tree";
        }
    }

    // Decorator
    public abstract class TreeDecorator : ChristmasTree
    {
        protected ChristmasTree _tree;

        public TreeDecorator(ChristmasTree tree)
        {
            _tree = tree;
        }

        public override string GetDescription()
        {
            return _tree.GetDescription();
        }

        public override void LightUp()
        {
            _tree.LightUp();
        }
    }

    // ConcreteDecorator 1: ornaments
    public class OrnamentsDecorator : TreeDecorator
    {
        // Extra field (as required by the task)
        private string _ornaments;

        public OrnamentsDecorator(ChristmasTree tree, string ornaments) : base(tree)
        {
            _ornaments = ornaments;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + $", decorated with ornaments ({_ornaments})";
        }
    }

    // ConcreteDecorator 2: garland
    public class GarlandDecorator : TreeDecorator
    {
        public GarlandDecorator(ChristmasTree tree) : base(tree)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", wrapped in a garland";
        }

        // Method responsible for the tree lighting up (as required by the task)
        public override void LightUp()
        {
            Console.WriteLine("The garland is on! The tree shines with colorful lights!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- 1. Bought a plain tree ---");
            ChristmasTree myTree = new BaseChristmasTree();
            Console.WriteLine(myTree.GetDescription());
            myTree.LightUp();
            Console.WriteLine();

            Console.WriteLine("--- 2. Added ornaments ---");
            myTree = new OrnamentsDecorator(myTree, "glass balls, star on top");
            Console.WriteLine(myTree.GetDescription());
            myTree.LightUp();
            Console.WriteLine();

            Console.WriteLine("--- 3. Added a garland ---");
            myTree = new GarlandDecorator(myTree);
            Console.WriteLine(myTree.GetDescription());
            myTree.LightUp(); // Now the tree shines thanks to the garland
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}