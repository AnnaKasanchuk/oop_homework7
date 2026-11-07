using System;
using System.Collections.Generic;

namespace CompositeExample
{
    public interface IFileSystemComponent
    {
        void Display(int depth);
    }

    public class FileItem : IFileSystemComponent
    {
        private string _name;

        public FileItem(string name)
        {
            _name = name;
        }

        public void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + " Файл: " + _name);
        }
    }

    public class ShortcutItem : IFileSystemComponent
    {
        private string _name;
        private string _target;

        public ShortcutItem(string name, string target)
        {
            _name = name;
            _target = target;
        }

        public void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + " Ярлик: " + _name + " -> " + _target);
        }
    }

    public class DirectoryItem : IFileSystemComponent
    {
        private string _name;
        private List<IFileSystemComponent> _components = new List<IFileSystemComponent>();

        public DirectoryItem(string name)
        {
            _name = name;
        }

        public void Add(IFileSystemComponent component)
        {
            _components.Add(component);
        }

        public void Remove(IFileSystemComponent component)
        {
            _components.Remove(component);
        }

        public void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + " Папка: " + _name);

            foreach (IFileSystemComponent component in _components)
            {
                component.Display(depth + 2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DirectoryItem rootDirectory = new DirectoryItem("C: (Кореневий диск)");

            FileItem file1 = new FileItem("readme.txt");
            FileItem file2 = new FileItem("sys_config.xml");

            DirectoryItem documentsDir = new DirectoryItem("Documents");
            FileItem docFile1 = new FileItem("report.docx");
            FileItem docFile2 = new FileItem("budget.xlsx");

            documentsDir.Add(docFile1);
            documentsDir.Add(docFile2);

            DirectoryItem secretDir = new DirectoryItem("Secret");
            secretDir.Add(new FileItem("passwords.txt"));
            documentsDir.Add(secretDir);

            rootDirectory.Add(file1);
            rootDirectory.Add(file2);
            rootDirectory.Add(documentsDir);

            rootDirectory.Add(new ShortcutItem("Ярлик на звіт", "Documents/report.docx"));

            Console.WriteLine("--- Структура файлової системи ---");
            rootDirectory.Display(1);

            Console.ReadKey();
        }
    }
}