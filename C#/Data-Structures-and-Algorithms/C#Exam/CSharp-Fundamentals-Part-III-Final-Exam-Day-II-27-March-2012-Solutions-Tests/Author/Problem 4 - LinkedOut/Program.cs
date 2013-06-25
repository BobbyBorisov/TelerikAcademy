using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4___LinkedOut
{
    class Program
    {
        static void Main()
        {
            // TestGenerator.GenerateTests(); return;

            string fromUser = Console.ReadLine();

            int connectionsCount = int.Parse(Console.ReadLine());
            List<Tuple<string, string>> connections = new List<Tuple<string, string>>(connectionsCount);
            for (int i = 1; i <= connectionsCount; i++)
            {
                string connectionAsString = Console.ReadLine();
                string[] connectionInParts = connectionAsString.Split(' ');
                Tuple<string, string> connectionAsTuple = new Tuple<string, string>(connectionInParts[0], connectionInParts[1]);
                connections.Add(connectionAsTuple);
            }

            int usersToCheckCount = int.Parse(Console.ReadLine());
            List<string> usersToCheck = new List<string>();
            for (int i = 1; i <= usersToCheckCount; i++)
			{
                string userToCheck = Console.ReadLine();
                usersToCheck.Add(userToCheck);
			}

            LinkedOut linkedOut = new LinkedOut(connections);

            List<int> degrees = linkedOut.FindConnectionDegrees(fromUser, usersToCheck);
            foreach (var item in degrees)
            {
                Console.WriteLine(item);
            }
        }
    }

    class LinkedOut
    {
        private readonly Dictionary<string, List<string>> listOfConnections;

        public LinkedOut(List<Tuple<string, string>> connections)
        {
            this.listOfConnections = new Dictionary<string, List<string>>();

            foreach (var connection in connections)
            {
                // Add the first user as a connection to the second user
                if (!listOfConnections.ContainsKey(connection.Item1))
                {
                    listOfConnections.Add(connection.Item1, new List<string>());
                }
                listOfConnections[connection.Item1].Add(connection.Item2);

                // Add the second user as a connection to the first user
                if (!listOfConnections.ContainsKey(connection.Item2))
                {
                    listOfConnections.Add(connection.Item2, new List<string>());
                }
                listOfConnections[connection.Item2].Add(connection.Item1);
            }
        }

        private List<int> BFS(string fromUser, List<string> toUsers)
        {
            Dictionary<string, int> degrees = new Dictionary<string,int>();
            HashSet<string> used = new HashSet<string>();
            Queue<Tuple<string, int>> bfsQueue = new Queue<Tuple<string, int>>(); // string = user, int = level

            used.Add(fromUser);
            bfsQueue.Enqueue(new Tuple<string, int>(fromUser, 0));

            while (bfsQueue.Count > 0)
            {
                var user = bfsQueue.Dequeue();
                
                degrees.Add(user.Item1, user.Item2);

                if (listOfConnections.ContainsKey(user.Item1))
                {
                    foreach (var connection in listOfConnections[user.Item1])
                    {
                        if (!used.Contains(connection))
                        {
                            used.Add(connection);
                            bfsQueue.Enqueue(new Tuple<string, int>(connection, user.Item2 + 1));
                        }
                    }
                }
            }

            List<int> connectionDegrees = new List<int>();

            foreach (var user in toUsers)
            {
                int connectionDegree = -1;
                if (degrees.ContainsKey(user))
                {
                    connectionDegree = degrees[user];
                }
                connectionDegrees.Add(connectionDegree);
            }

            return connectionDegrees;
        }

        public List<int> FindConnectionDegrees(string fromUser, List<string> toUsers)
        {
            List<int> connectionDegrees = BFS(fromUser, toUsers);
            return connectionDegrees;
        }
    }
}
