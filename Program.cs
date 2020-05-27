using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Data;
using System.Drawing;
using System.Reflection;

namespace Snake
{
    //Define a struct for the position of the snake and other objects.
    struct Position
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class Snake
    {

        // int score;
        private static int MainMenu()
        {
            //main menu options
           
            Console.Clear();
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "                                  88                 ");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "                                  88");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "                                  88");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + ",adPPYba,  8b,dPPYba,  ,adPPYYba, 88   ,d8  ,adPPYba,  ");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "I8[    ''  88P'   `'8a ''     `Y8 88 ,a8'  a8P_____88  ");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + " `'Y8ba,   88       88 ,adPPPPP88 8888[    8PP'''''''  ");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "aa    ]8I  88       88 88,    ,88 88`'Yba, '8b,   ,aa  ");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "`'YbbdP''  88       88 `'8bbdP'Y8 88   `Y8a `'Ybbd8''  ");


            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "                 ____");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "           _,.-'`_ o `;__,    ");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "            _.-'`'---'   '");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "                    ____");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "                 .'`_ o `;__,");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "      .       .'.'` '---'   '         ");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "      .`-...-'.'");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "       `-...-'");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "                        _,.--.");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "   --..,_            .'`__ o  `;__,");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "       `'.'.       .'.'`  '---'`  '     ");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "          '.`-...-'.'");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "            `-...-'");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "    --..,_                     _,.--.");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "       `'.'.                .'`__ o  `;__.   ");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "          '.'.            .'.'`  '---'`  `");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "            '.`'--....--'`.'");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "              `'--....--'`");
            Console.WriteLine( "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "");


            Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Please Press Enter To Continue...");
            Console.ReadLine();
            Console.Clear();


            Console.WriteLine("\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Choose an option:");
            Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "1) Start Game");
            Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "2) High Scores");
            Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "3) How to Play");
            Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "4) Exit");
            Console.Write("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Select an option: ");

            switch (Console.ReadLine())
            {
                //level selector
                case "1":
                    Console.Clear();
                    Console.WriteLine("\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "1)Normal Mode");
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "2)Hard Mode");
                    Console.Write("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Select an option: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            return 1;
                        case "2":
                            return 2;
                        default:
                            return 1;
                    }
                //show high scores
                case "2":
                    string path = @"userPoints.txt";
                    string readText = File.ReadAllText(path);
                    Console.WriteLine(readText);
                    Console.ReadKey();
                    return 1;

                case "3":
                    Console.Clear();
                    Console.WriteLine("\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\t" + "\t" + "\t" + "\t" + "\t" + "**##How To Play The Game!##**");
                    Console.WriteLine("\n");
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "The objective of the SnakeGame is to eat as much");
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "food possible and avoid the obstacles to make");
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "the snake longer and faster");
                    Console.WriteLine("\n");
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "*Press the 'P Key' to Pause the game and 'Enter Key' to Resume the game");
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "*Up key to move the Snake up");
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "*Down key to move the Snake  down");
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "*Right key to move the Snake right");
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "*Left key to move the Snake left");
                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "*Enter to exit the game after Game Over");
                    Console.ReadKey();
                    return 1;
                //exit the game
                case "4":
                    Environment.Exit(0);
                    return 1;
                default:
                    return 1;
            }
        }
        public void BgMusic()
        {
            //Create SoundPlayer objbect to control background music playback in the game
            SoundPlayer bgMusic = new SoundPlayer();
            //Locating the soundtrack in the directory
            bgMusic.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"\matter.wav";
            //Will loop the background music if it finishes
            bgMusic.PlayLooping();
        }
        //Method to draw the food
        public void DrawFood()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write("♥♥");
        }
        //Method to draw the obstacle
        public void DrawObstacle()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write("▒");
        }
        //Method to draw the snake body
        public void DrawSnakeBody()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("*");
        }
        //Method for the directional positions
        public void Direction(Position[] directions)
        {
            directions[0] = new Position(0, 1);
            directions[1] = new Position(0, -1);
            directions[2] = new Position(1, 0);
            directions[3] = new Position(-1, 0);
        }
        //Method to create obstacl and initialise certain random position of obstacles at every game play
        public void Obstacles(List<Position> obstacles)
        {
            Random rand = new Random();
            obstacles.Add(new Position(rand.Next(1, Console.WindowHeight), rand.Next(0, Console.WindowWidth)));
            obstacles.Add(new Position(rand.Next(1, Console.WindowHeight), rand.Next(0, Console.WindowWidth)));
            obstacles.Add(new Position(rand.Next(1, Console.WindowHeight), rand.Next(0, Console.WindowWidth)));
            obstacles.Add(new Position(rand.Next(1, Console.WindowHeight), rand.Next(0, Console.WindowWidth)));
            obstacles.Add(new Position(rand.Next(1, Console.WindowHeight), rand.Next(0, Console.WindowWidth)));
        }
        public void CheckUserInput(ref int direction, byte right, byte left, byte down, byte up)
        {
            //User key pressed statement: depends on which direction the user want to go to get food or avoid obstacle
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                if (userInput.Key == ConsoleKey.LeftArrow)
                {
                    if (direction != right) direction = left;
                }
                if (userInput.Key == ConsoleKey.RightArrow)
                {
                    if (direction != left) direction = right;
                }
                if (userInput.Key == ConsoleKey.UpArrow)
                {
                    if (direction != down) direction = up;
                }
                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    if (direction != up) direction = down;
                }
                if (userInput.Key == ConsoleKey.P)
                    Console.ReadLine();
            }
        }

        //Overloaded method for the GameOver part of the game.
        public int GameOver(Queue<Position> snakeElements, Position snakeNewHead, int negativePoints, List<Position> obstacles)
        {
            if (snakeElements.Contains(snakeNewHead) || obstacles.Contains(snakeNewHead))
            {
                LoseSound();
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;//Text colour for the game over screen                                     
                Console.WriteLine("\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Game Over!");
                int userPoints = (snakeElements.Count);    //points calculated for player
                                                               // userPoints = Math.Max(userPoints, 0);
                Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Your points are: {0}", userPoints);
                Console.Write("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Please enter your name: ");
                string user_name = Console.ReadLine();
                SaveFile(userPoints, user_name);//keeps the points and username is SaveFile to be written in to file
                //Exits the game when "Enter Key" is pressed
                Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Press Enter to exit the game!");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                return 1;
            }
            return 0;
        }
        //Method to create file and write to file the username and points.
        public void SaveFile(int userPoints, string user_name)
        {
            String filePath = Path.Combine(@"userPoints.txt");
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                    File.WriteAllText(filePath, user_name + "  " + userPoints.ToString() + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText(filePath, user_name + "  " + userPoints.ToString() + Environment.NewLine);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("{0} Exception caught.", exception);
            }
        }

        class Scoreboard
        {
            public static int Row1;
            public static int Col1;

            public static void Show(string a, int b, int c)
            {
             
                Console.SetCursorPosition(Col1 + b, Row1 + c);
                Console.SetCursorPosition(0, 0);
                Console.Write(a);
            }

            public static void WriteScore(int a, int b, int c)
            {
               
                Console.SetCursorPosition(Col1 + b, Row1 + c);
                Console.SetCursorPosition(14, 0);
                Console.Write(a);
            }
        }
        public void LoseSound()
        {
            SoundPlayer playerLose = new SoundPlayer();
            playerLose.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"\Lose.wav";
            playerLose.Play(); //Play the die sound effect after player died
        }





        //Main Program
        static void Main(string[] args)
        {
           
            Console.WindowHeight = 30;
            Console.WindowWidth = 130;

            // Set the Foreground color to blue 
            Console.BackgroundColor
                = ConsoleColor.White;

            // Display current Foreground color 
            Console.ForegroundColor = ConsoleColor.Black;
            //prevents from cursor showing
            Console.CursorVisible = false;
            byte right = 0;
            byte left = 1;
            byte down = 2;
            byte up = 3;
            int lastFoodTime = 0;
            int negativePoints = 0;
            int foodDissapearTime = 0;
            double sleepTime = 0;
            int score = 0;
            Position[] directions = new Position[4];
            Random rand = new Random();
            int showMenu = 0;

            Console.Beep(1188, 250); Console.Beep(1056, 250); Console.Beep(990, 500); Console.Beep(990, 250); Console.Beep(1056, 250); Console.Beep(1188, 500); Console.Beep(1320, 500); Console.Beep(1056, 500); Console.Beep(880, 500); Console.Beep(880, 500);

            while (showMenu == 0)
            {
                showMenu = MainMenu();//main menu
            }
            if (showMenu == 1)
            { // Normal Mode
                foodDissapearTime = 15000;
                sleepTime = 100;

                if (showMenu == 2)
                { // Hard Mode
                    foodDissapearTime = 7500;
                    sleepTime = 50;
                }
                Snake s = new Snake();

                // Define direction with characteristic of index of array
                s.BgMusic();
                s.Direction(directions);
                List<Position> obstacles = new List<Position>();

                if (showMenu == 1)
                {
                    s.Obstacles(obstacles);
                }
                if (showMenu == 2)
                {
                    s.Obstacles(obstacles);
                    obstacles.Add(new Position(rand.Next(1, Console.WindowHeight), rand.Next(0, Console.WindowWidth)));
                    obstacles.Add(new Position(rand.Next(1, Console.WindowHeight), rand.Next(0, Console.WindowWidth)));
                    obstacles.Add(new Position(rand.Next(1, Console.WindowHeight), rand.Next(0, Console.WindowWidth)));
                    obstacles.Add(new Position(rand.Next(1, Console.WindowHeight), rand.Next(0, Console.WindowWidth)));
                    obstacles.Add(new Position(rand.Next(1, Console.WindowHeight), rand.Next(0, Console.WindowWidth)));
                }
                //Initializes the direction of the snakes head and the food timer and the speed of the snake.
                int direction = right;
                Console.BufferHeight = Console.WindowHeight;
                lastFoodTime = Environment.TickCount;
                Console.Clear();
                Thread.Sleep(2000);
                //Loop to show obstacles in the console window
                foreach (Position obstacle in obstacles)
                {
                    Console.SetCursorPosition(obstacle.col, obstacle.row);
                    s.DrawObstacle();
                }
                //Initialise the snake position in top left corner of the windows
                //The snakes length is reduced to 3* instead of 5.
                Queue<Position> snakeElements = new Queue<Position>();
                for (int i = 0; i <= 3; i++) // Length of the snake was reduced to 3 units of *
                {
                    snakeElements.Enqueue(new Position(2, i));
                }
                //To position food randomly in the console
                Position food = new Position();
                do
                {
                    food = new Position(rand.Next(0, Console.WindowHeight), //Food generated within limits of the console height
                        rand.Next(0, Console.WindowWidth)); //Food generated within the limits of the console width
                }
                //loop to continue putting food in the game
                //put food in random places with "@" symbol
                while (snakeElements.Contains(food) || obstacles.Contains(food));
                Console.SetCursorPosition(food.col, food.row);
                s.DrawFood();
                //during the game, the snake is shown with "*" symbol
                foreach (Position position in snakeElements)
                {
                    Console.SetCursorPosition(position.col, position.row);
                    s.DrawSnakeBody();
                }
                while (true)
                {

                    //negative points increased if the food is not eaten in time
                    negativePoints++;
                    s.CheckUserInput(ref direction, right, left, down, up);
                    //Manages the position of the snakes head.
                    Position snakeHead = snakeElements.Last();
                    Position nextDirection = directions[direction];
                    //Snake position when it goes through the terminal sides
                    Position snakeNewHead = new Position(snakeHead.row + nextDirection.row,
                        snakeHead.col + nextDirection.col);
                    if (snakeNewHead.col < 0) snakeNewHead.col = Console.WindowWidth - 1;
                    //Snake cannot move into the score column with changes in this part of the code
                    if (snakeNewHead.row < 1) snakeNewHead.row = Console.WindowHeight - 1;
                    if (snakeNewHead.row >= Console.WindowHeight) snakeNewHead.row = 1;
                    if (snakeNewHead.col >= Console.WindowWidth) snakeNewHead.col = 0;

                    int gameOver = s.GameOver(snakeElements, snakeNewHead, negativePoints, obstacles);
                    if (gameOver == 1) //if snake hits an obstacle then its gameover
                        return;
                    //The position of the snake head according the body
                    Console.SetCursorPosition(snakeHead.col, snakeHead.row);
                    s.DrawSnakeBody();
                    //Snake head shape when the user presses the key to change his direction
                    snakeElements.Enqueue(snakeNewHead);
                    Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (direction == right) Console.Write(">"); //Snakes head when moving right
                    if (direction == left) Console.Write("<");//Snakes head when moving left
                    if (direction == up) Console.Write("^");//Snakes head when moving up
                    if (direction == down) Console.Write("v");//Snakes head when moving down
                    // food will be positioned in different column and row from snakes head and will not touch the score shown on console
                    if ((snakeNewHead.col == food.col +1 && snakeNewHead.row == food.row) || (snakeNewHead.col == food.col +1 && snakeNewHead.row == food.row))
                    {
                        if (snakeNewHead.col == food.col +1 && snakeNewHead.row == food.row)
                            score += (snakeElements.Count);
                        Scoreboard.Show("Current Score", 0, 1);
                        Scoreboard.WriteScore(score, 0, 2);
                        Console.Beep();//Beep when food is eaten
                        do
                        {
                            food = new Position(rand.Next(0, Console.WindowHeight),
                                rand.Next(0, Console.WindowWidth));
                        }
                        //if the snake consumes the food, lastfoodtime will be reset
                        //new food will be drawn and the snakes speed will increase
                        while (snakeElements.Contains(food) || obstacles.Contains(food));
                        lastFoodTime = Environment.TickCount;
                        Console.SetCursorPosition(food.col, food.row);
                        s.DrawFood();
                        sleepTime--;
                        //setting the obstacles in the game randomly
                        Position obstacle = new Position();
                        do
                        {
                            obstacle = new Position(rand.Next(0, Console.WindowHeight),
                                rand.Next(0, Console.WindowWidth));
                        }
                        //new obstacle will not be placed in the current position of the snake and previous obstacles.
                        //new obstacle will not be placed at the same row & column of food
                        while (snakeElements.Contains(obstacle) ||
                            obstacles.Contains(obstacle) ||
                            (food.row != obstacle.row && food.col != obstacle.row));
                        obstacles.Add(obstacle);
                       //new obstacles will not be placed on the score
                        Console.SetCursorPosition(obstacle.col +1, obstacle.row);
                        s.DrawObstacle();
                    }
                    else
                    {
                        // snakes movement shown by blank spaces
                        Position last = snakeElements.Dequeue();
                        Console.SetCursorPosition(last.col, last.row);
                        Console.Write(" ");
                    }
                    //if snake didnt eat in time, 50 will be added to negative points
                    //draw new food randomly after the previous one is eaten
                    if (Environment.TickCount - lastFoodTime >= foodDissapearTime)
                    {
                        negativePoints = negativePoints + 50;
                        Console.SetCursorPosition(food.col, food.row);
                        Console.Write(" ");
                        do
                        {
                            food = new Position(rand.Next(0, Console.WindowHeight),
                                rand.Next(0, Console.WindowWidth));
                        }
                        while (snakeElements.Contains(food) || obstacles.Contains(food));
                        lastFoodTime = Environment.TickCount;
                    }
                    //draw food with @ symbol
                    Console.SetCursorPosition(food.col, food.row);
                    s.DrawFood();
                    //snake moving speed increased by 0.01.
                    sleepTime -= 0.01;
                    //pause the execution of snake moving speed
                    Thread.Sleep((int)sleepTime);
                }
            }
        }

    }
}