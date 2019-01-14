/*
    Author: Clinton Daniel
    Date: 1/13/2019
    Comments: This script demonstrates the Binary Search Algorithm. The user will
              enter an integer between 1 and 20 (n). The script will then generate an
              array of (n) elements with random integer values between 0 and 20.
              Then, the console will display the array and ask the user to enter an
              integer value listed in the console. Then, the script will conduct the
              binary search for the integer value. If the integer value cannot be found,
              the script handles it by eventually exiting a while loop and displaying
              a message asking the user to try again. 
*/

using System;

namespace Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter an integeger value between 1 and 20: ");
            try
            {
                // This variable will gather data from user input
                string input = Console.ReadLine();
                // This variable will be used to perform the various iterative statements and is parsed as an integer
                int value_of_input = int.Parse(input);
                // min will be used to store the lowest random integer value that can be generated in the binary_search array
                int min = 0;
                // max will be used to store the maximum random integer value that can be generated in the binary_search array
                int max = 20;
                int[] binary_search = new int[value_of_input];
                // Generate a random number object instance called randNum
                Random randNum = new Random();

                // Populate the array with random numbers between 0 and 20
                for (int i = 0; i < value_of_input; i++)
                {
                    // Populate an element within the array with a random number between 0 and 20
                    binary_search[i] = randNum.Next(min,max);
                    // Display the randomly generated element to the console
                    Console.Write("  " + binary_search[i]);
                }

                Console.WriteLine("");
                Console.WriteLine("");
                // Here the user should enter an integer value from the list displayed by the array in the console
                Console.Write("Now enter one integer value from this array to conduct the Binary Search: ");

                // This variable will gather data from user input
                string get_search = Console.ReadLine();
                // This variable will be used to perform the various iterative statements and is parsed as an integer
                int value_of_get_search = int.Parse(get_search);

                // Now sort the integer values in the array as required by binary search
                Array.Sort(binary_search);
                Console.WriteLine("");
                Console.WriteLine("Here is the array with the integer values in order as required by Binary Search: ");
                Console.WriteLine("");

                // Print the ordered array to the console
                for (int i = 0; i < value_of_input; i++)
                {
                    Console.Write("  " + binary_search[i]);
                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Now let's search for your integer value ...");

                // get_middle will be used to get the element in the middle of the array. Initialize to 0 for now.
                int get_middle = 0;
                // This is the lower element of the array. Initialize to 0 for now. 
                int low = 0;
                // This is the upper element of the array
                int high = (binary_search.Length) - 1;
                // This is the middle of the array. mid is rounded down automatically if (low + high) is not an even number
                int mid = (low + high) / 2;
                // This variable is used to track where the middle is. You will later in this code how this prevents an infinite loop in the Binary Search
                int track_middle = 0;
                // Here is the Binary Search Algorithm
                while(low <= high)
                {
                    // Reset mid each time the while iterates
                    mid = (low + high) / 2;
                    // Get the middle element in the binary_search array
                    // Reset get middle each time the while loop iterates
                    get_middle = binary_search[mid];
                    // This will test to true if the match in the Binary Search is found
                    if(get_middle == value_of_get_search)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Found your integer! Here it is: " + value_of_get_search);
                        // Break out of the loop once the match for the search is found
                        break;
                    }
                    // The && get_middle != track_middle test is conducted in case an integer is entered by the user that does not exist in the array
                    // Also, this if statement is used to re-assign the value of high if needed 
                    if(get_middle > value_of_get_search && get_middle != track_middle)
                    {
                        high = mid + 1;
                        Console.WriteLine("");
                        Console.WriteLine("Found this integer: " + get_middle + " But that's not it!");
                        // Keep track of the middle by assigning the current middle value (get_middle) to track_middle
                        track_middle = get_middle;
                    }
                    // This re-assigns the value of low as needed in the loop
                    else
                    {
                        // If no match is found, low will continue to increase 1 more until it exceeds high (as tested in the while loop), then the loop will stop
                        // Otherwise, low will be used to continue the search
                        low = mid + 1;
                        Console.WriteLine("");
                        Console.WriteLine("Found this integer: " + get_middle + " But that's not it!");
                    }
                }
                
                // If a match is not found in the while loop about, this means that the value of low has exceeded high.
                // The value of low is tracked in the else statement within the while loop above
                if(low > high)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Could not locate your integer value in the search. Please try again... ");
                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Press any key to exit the program ...");
                Console.ReadKey(true);
            } // End of try
            catch
            {
                Console.WriteLine("Please enter an integer value");
            } // End of catch
        }


    }
}
