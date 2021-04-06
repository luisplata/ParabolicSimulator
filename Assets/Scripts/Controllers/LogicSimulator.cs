using Mathematics;
using UnityEngine;

namespace Controllers
{
    public class LogicSimulator
    {
        private readonly ISimulatorView _simulatorView;
        private Calculating _calculating;
        private float _angle;
        private float _inicialVelocity;
        private float _estimate;
        private float _lastPositionInX;

        public LogicSimulator(ISimulatorView simulatorView)
        {
            _simulatorView = simulatorView;
            
        }
        
        public void CalculateTrajectory()
        {
            _simulatorView.ResetList();
            _angle = _simulatorView.GetAngle();
            _inicialVelocity = _simulatorView.GetPower();
            _estimate = _simulatorView.GetEstimate();
            _calculating = new Calculating(_inicialVelocity, _angle, _simulatorView);
            var resultList = _calculating.Prediction();
            _lastPositionInX = Mathf.Abs(resultList[resultList.Count-1].x - _simulatorView.PositionInX());
            foreach (var position in resultList)
            {
                _simulatorView.CreatePoint(position);
            }
            
            if (MarginError(_lastPositionInX, _estimate) < 5)
            {
                _simulatorView.PlayerWin();
            }
            else
            {
                _simulatorView.PlayerFail();
            }
        }

        public float MarginError(float valorExacto, float valorAproximado)
        {
            return Mathf.Abs(((valorAproximado / valorExacto) * 100) - 100);
        }
    }
}