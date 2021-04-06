using System;
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
        private string ConvertTextNormalInFloat(string text)
        {
            var sstring = text.Replace(".", ",");
            return sstring==""?"0":sstring;
        }
        public void CalculateTrajectory()
        {
            try
            {
                _simulatorView.ResetList();
                _angle = float.Parse(ConvertTextNormalInFloat(_simulatorView.GetAngle()));
                _inicialVelocity = float.Parse(ConvertTextNormalInFloat( _simulatorView.GetPower()));
                _estimate =  float.Parse(ConvertTextNormalInFloat(_simulatorView.GetEstimate()));
                _calculating = new Calculating(_inicialVelocity, _angle, _simulatorView);
                var resultList = _calculating.Prediction();
                _lastPositionInX = Mathf.Abs(resultList[resultList.Count - 1].x - _simulatorView.PositionInX());
                _simulatorView.CreatePoints(resultList);
            }
            catch (CalculatinException e)
            {
                _simulatorView.ShowMessage(e.Message);
            }
            catch (FormatException e)
            {
                _simulatorView.ShowMessage("Hay un valor que no es numerico");
            }
        }

        public void CalculateMatgin()
        {
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