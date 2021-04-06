using System.Collections.Generic;
using Controllers;
using TMPro;
using Mathematics;
using UnityEngine;

namespace View
{
    public class Simulator : MonoBehaviour, ISimulatorView
    {
        private LogicSimulator _logic;

        [SerializeField] private Animator _animator;

        [SerializeField] private GameObject point;

        [SerializeField] private TMP_InputField inicialVelocity, angle, estimate;

        private float _angle, _inicialVelocity, _estimate;

        private List<GameObject> _listOfPoints;
        // Start is called before the first frame update
        void Start()
        {
            _listOfPoints = new List<GameObject>();
            _logic = new LogicSimulator(this);
            ResetAll();
        }

        public void Calculate()
        {
            _logic.CalculateTrajectory();
        }

        public void ResetAll()
        {
            inicialVelocity.text = "0";
            angle.text = "0";
            estimate.text = "0";
            DestroidAll();
        }

        public float PositionInX()
        {
            return transform.position.x;
        }

        public float PositionInY()
        {
            return transform.position.y;
        }

        public float GetAngle()
        {
            return float.Parse(ConvertTextNormalInFloat(angle.text));
        }

        private string ConvertTextNormalInFloat(string text)
        {
            return text.Replace(".", ",");
        }

        public float GetPower()
        {
            return float.Parse(ConvertTextNormalInFloat(inicialVelocity.text));
        }

        public float GetEstimate()
        {
            return float.Parse(ConvertTextNormalInFloat(estimate.text));
        }

        public void CreatePoint(Vector2 position)
        {
            var pointInstantiate = Instantiate(point);
            pointInstantiate.transform.position = position;
            _listOfPoints.Add(pointInstantiate);
        }

        public void PlayerWin()
        {
            _animator.SetTrigger("win");
        }

        public void PlayerFail()
        {
            _animator.SetTrigger("lose");
        }

        public void ResetList()
        {
            DestroidAll();
        }

        private void DestroidAll()
        {
            foreach (var pointInWord in _listOfPoints)
            {
                Destroy(pointInWord);
            }
        }
    }
}
