using System;
using System.Collections;
using System.Collections.Generic;
using Autofac;
using Autofac.Features.Metadata;

namespace AdapterDependencyInject
{
    public interface ICommand
    {
        void Execute();
    }

    class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Save to file");
        }
    }

    class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Open file");
        }
    }

    public class Button
    {
        private ICommand command;
        private string name;

        public Button(ICommand command, string name)
        {
            this.command = command;
            this.name = name;
        }

        public void PrintMe()
        {
            Console.WriteLine($"I am a button called {name}");
        }

        public void Click()
        {
            command.Execute();
        }
    }

    public class Editor
    {
        private IEnumerable<Button> buttons;
        public IEnumerable<Button> Buttons => buttons;

        public Editor(IEnumerable<Button> buttons)
        {
            this.buttons = buttons;
        }

        public void ClickAll()
        {
            foreach(var button in buttons)
            {
                button.Click();
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var b = new ContainerBuilder();
            b.RegisterType<SaveCommand>().As<ICommand>().WithMetadata("Name", "Save");
            b.RegisterType<OpenCommand>().As<ICommand>().WithMetadata("Name", "Open"); ;
            //registering as adapter here
            b.RegisterAdapter<Meta<ICommand>, Button>(cmd => new Button(cmd.Value, (string)cmd.Metadata["Name"]));
            b.RegisterType<Editor>();

            using (var c = b.Build())
            {
                var editor = c.Resolve<Editor>();

                foreach(var btn in editor.Buttons)
                {
                    btn.PrintMe();
                }
            }
        }
    }
}
