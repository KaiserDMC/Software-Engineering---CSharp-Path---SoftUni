using System;
using System.Collections.Generic;

namespace Basketball
{
    public class StartUp
    {
        static void Main()
        {
            // Initialize the repository (Team)
            Team team = new Team("BHTC", 5, 'A');

            // Initialize entity
            Player firstPlayer = new Player("Viktor", "Center", 97.5, 10);

            // Print player
            Console.WriteLine(firstPlayer);
            /*
            -Player: Viktor
            --Position: Center
            --Rating: 97.5
            --Games played: 10
            */

            // Add Player
            Console.WriteLine(team.AddPlayer(firstPlayer));
            /* 
            Successfully added Viktor to the team. Remaining open positions: 4.
            */

            // Check count of added players
            Console.WriteLine(team.Count);
            /* 
            1
            */

            // Remove Player
            Console.WriteLine(team.RemovePlayer("Slavi"));
            /* 
            False
            */

            Player secondPlayer = new Player("Slavi", "Point Guard", 94.3, 47);
            Player thirdPlayer = new Player("Evgeni", "Shooting Guard", 93.7, 16);
            Player fourthPlayer = new Player("Momchil", "Small forward", 67.9, 3);
            Player fifthPlayer = new Player("Vasil", "Power forward", 86.9, 10);
            Player sixthPlayer = new Player("Stefan", "Center", 95.6, 25);
            Player seventhPlayer = new Player("Ivan", " Small forward ", 98.5, 89);


            // Add players
            Console.WriteLine(team.AddPlayer(secondPlayer));
            Console.WriteLine(team.AddPlayer(thirdPlayer));
            Console.WriteLine(team.AddPlayer(fourthPlayer));
            Console.WriteLine(team.AddPlayer(fifthPlayer));
            Console.WriteLine(team.AddPlayer(sixthPlayer));
            Console.WriteLine(team.AddPlayer(seventhPlayer));
            /*
            Successfully added Slavi to the team. Remaining open positions: 3
            Successfully added Evgeni to the team. Remaining open positions: 2
            Invalid player's rating
            Successfully added Vasil to the team. Remaining open positions: 1
            Successfully added Stefan to the team. Remaining open positions: 0
            There are no more open positions.
            */

            // Retire player by name
            Console.WriteLine(team.RetirePlayer("Slavi"));
            /*
            -Player: Slavi
            --Position: Point Guard
            --Rating: 94.3
            --Games played: 47
            */

            // Award players
            List<Player> players = team.AwardPlayers(15);
            foreach (var playerToBeAwarded in players)
            {
                Console.WriteLine(playerToBeAwarded);
            }
            /*
            -Player: Slavi
            --Position: Point Guard
            --Rating: 94.3
            --Games played: 47
            -Player: Evgeni
            --Position: Shooting Guard
            --Rating: 93.7
            --Games played: 16
            -Player: Stefan
            --Position: Center
            --Rating: 95.6
            --Games played: 25
            */

            // Remove player by position
            Console.WriteLine(team.RemovePlayerByPosition("Center"));
            /*
            2
            */

            // Report
            Console.WriteLine("----------------------Report----------------------");
            Console.WriteLine(team.Report());
            /*
             Active players competing for Team BHTC from Group A:
            -Player: Evgeni
                --Position: Shooting Guard
                --Rating: 93.7
                --Games played: 16
            -Player: Vasil
                --Position: Power forward
                --Rating: 86.9
                --Games played: 10
            */
        }
    }
}