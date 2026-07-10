
// Breadth-First Search method
public void BFS(int startVertex)
{
    // Keep track of visited nodes
    bool[] visited = new bool[vertices];
    // Queue for BFS
    Queue<int> queue = new Queue<int>();

    // Mark the starting vertex as visited and enqueue it
    visited[startVertex] = true;

    queue.Enqueue(startVertex);

    Console.WriteLine("Breadth-First Search starting from vertex "
        + startVertex + ":");

    while (queue.Count > 0)
    {
        // Dequeue a vertex and print it
        int currentVertex = queue.Dequeue();
        Console.Write(currentVertex + " ");

        // Get all adjacent vertices
        foreach (var neighbor in adjacencyList[currentVertex])
        {
            if (!visited[neighbor])
            {
                // Mark as visited and enqueue
                visited[neighbor] = true;
                queue.Enqueue(neighbor);
            }
        }
    }
    Console.WriteLine(); // For a clean output
}