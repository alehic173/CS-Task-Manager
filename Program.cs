using System;
using System.Collections.Generic;
// The namespace makes it easier to organize our application and 
// avoid name collisions with other code
namespace HelloWorld
{
    // In .NET our program is contained within its own class
    class Program
    {
        // The main function is the entry point into our app
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to task tracker!");
            Console.WriteLine("1. Add new task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark task as complete");
            Console.WriteLine("4. Exit");
            bool statement = true;
            TaskManager taskManager = new TaskManager();
            while(statement)
            {
                Console.WriteLine("Please select an option: ");
                if(int.TryParse(Console.ReadLine(), out int choice))
                {
                    if(choice < 0 || choice > 4)
					{
                        Console.WriteLine("Please enter a valid number");
                        break;
                    }
                    switch(choice)
                    {
                        case 1: 
                            Console.WriteLine("Enter Title");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter Description");
                            string description = Console.ReadLine();
                            taskManager.AddTask(title, description);
                            Console.WriteLine("New Task Created!");
                            break;
                        case 2:
                            taskManager.Display();
							break;
                        case 3:
                            Console.WriteLine("Enter Index");
							int.TryParse(Console.ReadLine(), out int index);
                            taskManager.markComplete(index);
                            Console.WriteLine("Task marked complete!");
							break;
                        case 4:
                            statement = false;
							break;

                    }        

                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                    break;
                }
            }
            

            // create a string variable and ask the user for some input
            string str = Console.ReadLine();
            Console.WriteLine("Why, hello there " + str);
        }
    }

    class Task
    {
        public string Title 
		{
			get 
			{
			 	return _title;
			}
		}
		public string Description 
		{
			get 
			{
			 	return _description;
			}
		}
        
        private bool _isComplete;
		private string _title;
		private string _description;
        public bool IsComplete 
		{ 
            get 
			{
			 	return _isComplete;
			}
            set
			{
				_isComplete = value;
			}
        }
		
        public Task(string title, string description, bool isComplete)
        {
            _title = title;
            _description = description;
            _isComplete = isComplete;
        }
    }
    class TaskManager{
        private List<Task> tasks = new List<Task>();

        public void AddTask(string title, string description)
		{
            Task newTask = new Task(title,description,false);
            tasks.Add(newTask);
        }

        public void Display()
        {
            foreach (Task task in tasks)
            {
                Console.WriteLine($"[{task.IsComplete}] {task.Title} , {task.Description}");
            }
        }
        public void markComplete(int index)
		{
            tasks[index].IsComplete = true;
        }


    }
}
