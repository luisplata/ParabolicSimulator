using UnityEngine;

namespace Mathematics
{
    public interface ISimulatorView
    {
        float PositionInX();
        float PositionInY();
        float GetAngle();
        float GetPower();
        float GetEstimate();
        void CreatePoint(Vector2 position);
        void PlayerWin();
        void PlayerFail();
        void ResetList();
    }
}