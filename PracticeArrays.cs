public static class PracticeArrays
{
    public static void One()
    {
        int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] a2 = new int[a.Length];
        Console.WriteLine($"Original array: {string.Join(",", a)}");
        Console.WriteLine($"New array: {string.Join(",", a2)}");
        for (int i = 0; i < a.Length; i++)
        {
            a2[i] = a[i];
            Console.WriteLine($"From original array:{a[i]}");
            Console.WriteLine($"Input new array:{a2[i]}");
        }

        Console.WriteLine($"Final original array: {string.Join(",", a)}");
        Console.WriteLine($"Final new array: {string.Join(",", a2)}");
    }

    public static void Two()
    {
        bool toDo = true;
        List<string> items = new List<string> { };
        while (toDo)
        {
            Console.WriteLine("Enter command (E to Exit and Show List, + item, - item, or -- to clear)):");
            String input = Console.ReadLine()!;
            if (input.StartsWith("+ ") && input.Length > 2)
            {
                string item = input.Substring(2).Trim();
                items.Add(item);
            } else if (input.StartsWith("- ") && input.Length > 2)
            {
                string item = input.Substring(2).Trim();
                items.Remove(item);
            } else if (input.StartsWith("--"))
            {
                items.Clear();
            } else if (input == "E")
            {
                Console.WriteLine($"Final items:{string.Join(",", items)}");
                return;
            } else
            {
                Console.WriteLine("Invalid command");
                continue;
            }

            Console.WriteLine(input);
        }
    }

    public static void Three()
    {
        {
            Console.WriteLine("All prime numbers in given range, Enter int(e.g. 10,20):");
            string[] input = Console.ReadLine()!.Split(',');
            int startNum = int.Parse(input[0]);
            int endNum = int.Parse(input[1]);
            FindPrimesInRange(startNum, endNum);

            static int[] FindPrimesInRange(int startNum, int endNum)
            {
                List<int> list = new List<int>();
                for (int i = startNum; i <= endNum; i++)
                {
                    bool isPrime = true;
                    int j = 2;
                    while (j <= Math.Sqrt(i) && isPrime)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                        }

                        j++;
                    }

                    if (isPrime && i >= 2)
                    {
                        list.Add(i);
                    }
                }

                int[] output = list.ToArray();
                Console.WriteLine($"Final prime numbers: {string.Join(",", output)}");
                return output;
            }
        }
    }

    public static void Four()
    {
        Console.WriteLine("Input(e.g. 3 2 4 -1): ");
        int[] input = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Console.WriteLine("Rotation(e.g. 2): ");
        int rotationCount = int.Parse(Console.ReadLine()!);
        int len = input.Length;
        int[] sumArray = new int[len];
        for (int r = 1; r <= rotationCount; r++)
        {
            for (int i = 0; i < len; i++)
            {
                sumArray[(i + r) % len] += input[i];
            }
        }

        Console.WriteLine($"Output:\n{string.Join(" ", sumArray)}");
    }

    public static void Five()
    {
        Console.WriteLine("Input(e.g. 2 1 1 2 3 3 2 2 2 1): ");
        int[] input = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        // start: current sequence start index, len: current sequence length
        int start = 0, len = 1;
        // maxStart: longest sequence start, maxLen: best sequence length
        int maxStart = 0, maxLen = 1;
        for (int i = 1; i < input.Length; i++)
        {
            // if current is same as previous, len++
            if (input[i] == input[i - 1])
            {
                len++;
            } else // starts at current, len = 1
            {
                len = 1;
                start = i;
            }

            if (len > maxLen)
            {
                maxLen = len;
                maxStart = start;
            }
        }

        Console.WriteLine("Output:");
        for (int i = maxStart; i < maxStart + maxLen; i++)
        {
            Console.Write($"{input[i]} ");
        }
    }

    public static void Six()
    {
        Console.WriteLine("Input(e.g. 4 1 1 4 2 3 4 4 1 2 4 9 3): ");
        int[] input = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int maxCount = 0, result = input[0]; //maxCount:the highest frequency, result:number as most frequency  
        for (int i = 0; i < input.Length; i++)
        {
            int count = 1; //Use for times for input[i] in array
            for (int j = i + 1; j < input.Length; j++) // check input[i] for all number to its right
            {
                if (input[j] == input[i])
                {
                    count++;
                }
            }

            if (count > maxCount)
            {
                maxCount = count; // update highest frequency
                result = input[i]; // store currentInt as most
            }
        }

        Console.WriteLine($"Output:\nThe number {result} is the most frequent (occurs {maxCount} times)");
    }
}
