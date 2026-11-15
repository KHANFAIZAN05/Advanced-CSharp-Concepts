using Bounded_Priority_Queue_with_Eviction;

Console.Write("Enter queue capacity: ");
if (!int.TryParse(Console.ReadLine(), out int capacity) || capacity <= 0)
{
    Console.WriteLine("Invalid capacity. Using default capacity = 3.");
    capacity = 3;
}

BoundedPriorityQueue<string, int> queue = new(capacity);

while (true)
{
    Console.Clear();
    Console.WriteLine("=== Bounded Priority Queue Menu ===");
    Console.WriteLine("1. Enqueue item");
    Console.WriteLine("2. Dequeue item");
    Console.WriteLine("3. Peek item");
    Console.WriteLine("4. Display all items");
    Console.WriteLine("5. Show queue info");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter item value: ");
            string item = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter priority (int): ");
            if (!int.TryParse(Console.ReadLine(), out int priority))
            {
                Console.WriteLine("Invalid priority. Enqueue canceled.");
                break;
            }

            int oldCount = queue.Count;
            queue.Enqueue(item, priority);

            if (oldCount == queue.Capacity)
            {
                Console.WriteLine($"Activity: Enqueue -> Queue was full, lowest-priority item evicted. Added '{item}' with priority {priority}.");
            }
            else
            {
                Console.WriteLine($"Activity: Enqueue -> Added '{item}' with priority {priority}.");
            }
            break;

        case "2":
            if (queue.Count == 0)
            {
                Console.WriteLine("Activity: Dequeue -> Queue is empty.");
                break;
            }

            string removedItem = queue.Dequeue();
            Console.WriteLine($"Activity: Dequeue -> Removed '{removedItem}'.");
            break;

        case "3":
            if (queue.Count == 0)
            {
                Console.WriteLine("Activity: Peek -> Queue is empty.");
                break;
            }

            string peekedItem = queue.Peek();
            Console.WriteLine($"Activity: Peek -> Current top item is '{peekedItem}'.");
            break;

        case "4":
            Console.WriteLine("Activity: Display -> Items in queue:");
            if (queue.Count == 0)
            {
                Console.WriteLine("(empty)");
                break;
            }

            int index = 1;
            foreach (string qItem in queue)
            {
                Console.WriteLine($"{index++}. {qItem}");
            }
            break;

        case "5":
            Console.WriteLine($"Activity: Info -> Count: {queue.Count}, Capacity: {queue.Capacity}");
            break;

        case "0":
            Console.WriteLine("Exiting application.");
            return;

        default:
            Console.WriteLine("Invalid option. Please choose from the menu.");
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey(intercept: true);
}
