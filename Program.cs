using System;
using System.Linq;
using System.Collections.Generic;
using System.IO.Compression;

namespace DailySchedule
{
  class Program
  {
    static bool BoolPrompt(string prompt)
    {
      Console.Write(prompt);
      bool userInput;
      while (!bool.TryParse(Console.ReadLine(), out userInput))
      {
        Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
        Console.Write(prompt);
      }
      return userInput;
    }

    static string StringPrompt(string prompt)
    {
      Console.Write(prompt);
      var userInput = Console.ReadLine();

      return userInput;
    }

    static void Greetings()
    {

      Console.WriteLine($"Welcome to the Daily Schedule");
      Console.WriteLine($"Todays date is {DateTime.Now.ToString("yyyy-MM-dd")}");

    }

    static void Main(string[] args)
    {
      var scheduling = new List<Schedule>();

      Greetings();

      bool keepMenuGoing = true;




      while (keepMenuGoing)
      {

        Console.WriteLine("Ed's Assignments, would you like to:\n(A)Add Assignment \n(E)Edit \n(V)View Assignments \n(C)Competition \n(Q)Quit:  ");
        var userMenuInput = Console.ReadLine().ToLower();

        if (userMenuInput == "a")
        {

          var Schedule = new Schedule();

          Schedule.Assignment = StringPrompt("What is your new Assignment? ");
          Schedule.DueDate = StringPrompt("when is the Due Date- And give it by dd-m-yyyy? ");
          Schedule.Completed = BoolPrompt("Is it completed? (true) or (false)? - type out the word, please: ");



          scheduling.Add(Schedule);



        }
        else if (userMenuInput == "v")
        {
          Console.WriteLine("Viewing all Assignments: ");

          foreach (var assignment in scheduling)
          {

            Console.WriteLine($"\nAssignment Id: {assignment.Id} \nIs assignment completed: {assignment.Completed} \nAssignment: {assignment.Assignment} \nDueDate: {assignment.DueDate}\n");
          }


        }
        else if (userMenuInput == "e")
        {
          Console.WriteLine($"What is the Id for the assignment you want to edit?: ");
          int editId = int.Parse(Console.ReadLine());

          var assignmentToEdit = scheduling.FirstOrDefault(value => value.Id == editId);

          if (assignmentToEdit != null)
          {

            Console.WriteLine($"This is the assignment you will be editing:\n{assignmentToEdit.Assignment}");

            assignmentToEdit.Assignment = StringPrompt("What is you New Assignment?: ");
            assignmentToEdit.DueDate = StringPrompt("What is your New Due Date? ");



          }
          else
          {
            Console.WriteLine("Invalid Number");
          }

        }
        else if (userMenuInput == "c")
        {

          Console.WriteLine($"What is the Id for the assignment you want to change completion?: ");
          int boolId = int.Parse(Console.ReadLine());

          var assignmentToEdit = scheduling.FirstOrDefault(value => value.Id == boolId);

          if (assignmentToEdit != null)
          {
            Console.WriteLine($"Your assignment: {assignmentToEdit.Assignment} and its Completion: {assignmentToEdit.Completed} that you would like to change");

            assignmentToEdit.Completed = BoolPrompt("Is it Completed? (True) / (False)");
          }



        }
        else
        {
          keepMenuGoing = false;
        }





      }




    }
  }
}
