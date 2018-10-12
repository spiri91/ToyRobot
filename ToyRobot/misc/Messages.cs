namespace ToyRobot.misc
{
    public static class Messages
    {
        public const string IntroInfo = @"
                Welcome to my toy robot :) 
        ";

        public const string Commands = @" 

                Commands: place (p) x:int y:int c:Cardinal (where cardinal 'S','W','E','N')
                          report (re) 
                          move (m)
                          left (l)
                          right (r)

        ";

        public const string Robot = @"

                           _(\    |@@|
                          (__/\__ \--/ __
                             \___|----|  |   __
                                 \ }{ /\ )_ / _\
                                 /\__/\ \__O (__
                                (--/\--)    \__/
                                _)(  )(_
                               `---''---`
                                           ";

        public static string Arrow = @">>-----> ";

        public static string CellRobot = @"<R>";

        public static string EmptyTable = @"
                      1      2      3      4      5
                  |¯¯¯¯¯¯|¯¯¯¯¯¯|¯¯¯¯¯¯|¯¯¯¯¯¯|¯¯¯¯¯¯|
                5 | {21} | {22} | {23} | {24} | {25} |
                  |______|______|______|______|______|
                  |      |      |      |      |      |
               4  | {16} | {17} | {18} | {19} | {20} |
                  |______|______|______|______|______|
                  |      |      |      |      |      |
               3  | {11} | {12} | {13} | {14} | {15} |
                  |______|______|______|______|______|
                  |      |      |      |      |      |
               2  | {6}  | {7}  | {8}  | {9}  | {10} |
                  |______|______|______|______|______|
                  |      |      |      |      |      |
               1  | {1}  | {2}  | {3}  | {4}  | {5}  |
                  |______|______|______|______|______|
                ";

        public static string WaitingInstructions = "Waiting instructions...";

        public static string BabyCrying = "Baby don't hurt me.. no more..";

        public static string BadCommand = "Didn't get that.. try again..";

        public static string FirstCommand = "First command should be a place command";
    }
}