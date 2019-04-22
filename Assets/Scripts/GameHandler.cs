﻿using UnityEngine;

public class GameHandler : MonoBehaviour
{ 
    public GameObject ActiveTetrimo;
    public Vector3Int DropVector3 = new Vector3Int(0,1,0);
    public float TetrimoHangTime = 1.0f;
    public float TetrimoSpeedChangeDelay = 2.0f;
    public int GameScore = 0;
    public GameObject TetrimoBaseBlock; // Assigned in Unity Editor
    public Vector2 TetrimoCreationPoint; // Assigned in Unity Editor

    private TetrimoManager _tetrimoManager; // Can create a shape in the scene.


    // Start is called before the first frame update
    void Start()
    {
        _tetrimoManager = new TetrimoManager(TetrimoBaseBlock, TetrimoCreationPoint);
        ActiveTetrimo = _tetrimoManager.CreateRandomTetrimo();
        InvokeRepeating("dropActiveTetrimo", TetrimoSpeedChangeDelay, TetrimoHangTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void dropActiveTetrimo()
    {
        if (!isActiveTetrimoAboutToCollide())
        {
            ActiveTetrimo.transform.position -= DropVector3;
        }
        else
        {
            ActiveTetrimo = null;
        }
    }

    bool isDropSpeedUpdateRequired()
    {
        if (GameScore > 2000)
            return true;
        return false;
    }

    void updateDropSpeed()
    {
        TetrimoHangTime -= 0.2f;
        CancelInvoke("dropActiveTetrimo");
        InvokeRepeating("dropActiveTetrimo",TetrimoSpeedChangeDelay, TetrimoHangTime);
    }

    bool isActiveTetrimoAboutToCollide()
    {
        return false;
    }
}
