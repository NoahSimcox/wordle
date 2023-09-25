using System;
using System.IO;
using System.Linq;

class Program {
  public static void Main (string[] args)
  {

    Console.Write("Wordle");

    var rand = new Random();
    int randInt = rand.Next(0, 3103);
    
    string answerWord = File.ReadLines("wordleWords.txt").Skip(randInt).First();

    for (int i = 0; i < 6; i++)
    {
      //just a spacer between each word
      Console.WriteLine();
      
      string input = Console.ReadLine();

      if (input.Length != 5)
      {
        i--;
        Console.Write("Try Again");
        continue;
      }

      int lettersRight = 0;

      for (int j = 0; j < 5; j++)
      {
        
        char inputLetter = input[j];
        char ansLetter = answerWord[j];
        //totally right
        if (inputLetter == ansLetter)
        {
          Console.Write("[" + inputLetter + "]");
          lettersRight++;
        }
        //right letter wrong spot
        else if (answerWord.Contains(inputLetter))
          Console.Write("{" + inputLetter + "}");
        //totally wrong
        else
          Console.Write("(" + inputLetter + ")");
        
        if (lettersRight == 5)
        {
          Console.WriteLine("\nYou Won");
          return;
        }            
      }
    }
    Console.WriteLine("\nYou Lost\nthe Word was " + answerWord);

  }
}