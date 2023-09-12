using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AlanZucconi.Tetris;
using AlanZucconi.AI.Evo;

public class TetrisWorld_aanim004 : MonoBehaviour,
    IWorld<ArrayGenome>,
    IGenomeFactory<ArrayGenome>
{
    public TetrisGame Tetris;
    public TetrisAI_Evolution_aanim004 AI;

    private ArrayGenome Genome;


    #region IWorld
    public void ResetSimulation()
    {
        //AI = ScriptableObject.CreateInstance<TetrisAI_Evolution_aanim004>();
        //Tetris.TetrisAI = AI;
    }

    public void SetGenome(ArrayGenome genome)
    {
        //AI.a = (float)Mathf.Lerp(-2, 2, genome.Params[0]);

        Genome = genome;
    }

    public ArrayGenome GetGenome()
    {
        return Genome;
    }

    public void StartSimulation()
    {
        Tetris.StartGame();
    }

    public bool IsDone()
    {
        return !Tetris.Running;
    }

    public float GetScore()
    {
        return Tetris.Turn;
    }
    #endregion

    #region IGenomeFactory
    public ArrayGenome Instantiate()
    {
        ArrayGenome genome = new ArrayGenome(1);
        genome.InitialiseRandom();
        return genome;
    }
    #endregion
}


