using System.Collections.Generic;
using UnityEngine;

namespace Mathematics
{
    public interface ISimulatorView
    {
        float PositionInX();
        float PositionInY();
        string GetAngle();
        string GetPower();
        string GetEstimate();
        void CreatePoint(Vector2 position);
        void PlayerWin();
        void PlayerFail();
        void ResetList();
        void ShowMessage(string message);
        void CreatePoints(List<Vector2> resultList);
    }
}