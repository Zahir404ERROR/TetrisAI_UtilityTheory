using UnityEngine;
using System;
using AlanZucconi.Tetris;

[CreateAssetMenu
(
    fileName = "TetrisAI_aanim004",
    menuName = "Tetris/2022-23/TetrisAI_aanim004"
)]
public class TetrisAI_aanim004 : TetrisAI
{
    // Weights for Heuristics
    float a = -1f;
    float b = -1.5f;
    float c = -0.95f;
    float d = -0.13f;
    float e = 1f;

    public override int ChooseMove(Move[] moves)
    {
        // Loops through all the moves,
        // Retrieving Heuristiics with weightages multiplied to them,
        // and returns the index of the move with the highest value based on the predefined heuristics

        return moves.IndexOfMax(move => Heuristic(move));
    }

    // Calculates Heuristiics and multiplies values with appropriate weights
    private float Heuristic(Move move)
    {
        // Simulates the effect of the move on the board
        TetrisState state = Tetris.SimulateMove(move);

        float minHeight = Convert.ToSingle(a * MaxColumnHeight(move));
        float aggregateHeight = Convert.ToSingle(b * AggregateHeight(move));
        float emptyCells = Convert.ToSingle(c * GetEmptyCellsInBottomRow(move));
        float bumbiness = Convert.ToSingle(d * GetBumbiness(move));
        float completedRows = Convert.ToSingle(e * CompletedRows(move));

        float heuristic = minHeight + emptyCells + bumbiness + completedRows + aggregateHeight;
        return heuristic;

    }

    // Calculates Max Column Height for the move
    private float MaxColumnHeight(Move move)
    {
        // Simulates the effect of the move on the board
        TetrisState state = Tetris.SimulateMove(move);

        // Loops through all columns
        int maxHeight = 0;
        for (int x = 0; x < Tetris.Size.x; x++)
        {
            int height = state.GetColumnHeight(x);

            // Finds the maximum
            if (height > maxHeight)
                maxHeight = height;
        }

        return maxHeight;
    }

    // Calculates Aggregate Height for the move
    private float AggregateHeight(Move move)
    {
        // Simulates the effect of the move on the board
        TetrisState state = Tetris.SimulateMove(move);

        // Loops through all columns
        int AggrHeight = 0;
        for (int x = 0; x < Tetris.Size.x; x++)
        {
            int height = state.GetColumnHeight(x);

            AggrHeight = AggrHeight + height;
        }

        return AggrHeight;
    }

    // Calculates Empty Cells for the move
    private float GetEmptyCellsInBottomRow(Move move)
    {
        // Simulates the effect of the move on the board
        TetrisState state = Tetris.SimulateMove(move);

        // Loops through all columns
        int emptyCells = 0;
        for (int x = 0; x < Tetris.Size.x; x++)
        {
            // Checks the bottom row
            if (state.IsEmpty(x, state.GetColumnHeight(x)))
            {
                emptyCells++;

            }
        }
        return emptyCells;
    }

    // Calculates Bumbiness for the move
    private float GetBumbiness(Move move)
    {
        // Simulates the effect of the move on the board
        TetrisState state = Tetris.SimulateMove(move);

        int bumbiness = 0;
        // Loops through all cells on the x axis
        for (int x = 0; x < Tetris.Size.x; x++)
        {
            bumbiness = Math.Abs(state.GetColumnHeight(x) - state.GetColumnHeight(x + 1));
        }
        return bumbiness;
    }

    // Calculates Completed Rows for the move
    private float CompletedRows(Move move)
    {
        // Simulates the effect of the move on the board
        TetrisState state = Tetris.SimulateMove(move);

        int completedRows = 0;
        // Loops through all rows
        for (int y = 0; y < Tetris.Size.y; y++)
        {
            if (state.IsRowFull(y))
            {
                completedRows++;
            }
        }
        return completedRows;
    }

}


