using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int playerOneWins = 0;
    public static int playerTwoWins = 0;

    public static int playerOneTotalWins = 0;
    public static int playerTwoTotalWins = 0;

    public static void ResetWins()
    {
        playerOneWins = 0;
        playerTwoWins = 0;
    }
    public static void ResetTotalWins()
    {
        playerOneWins = 0;
        playerTwoWins = 0;
        playerOneTotalWins = 0;
        playerTwoTotalWins = 0;
    }
}
