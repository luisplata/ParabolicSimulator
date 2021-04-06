using System.Collections;
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
        [SerializeField] private ShowMensaje messages;

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

        public string GetAngle()
        {
            return angle.text;
        }

        

        public string GetPower()
        {
            return inicialVelocity.text;
        }

        public string GetEstimate()
        {
            return estimate.text;
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

        public void ShowMessage(string message)
        {
            messages.ShowMesage(message);            
        }

        public void CreatePoints(List<Vector2> resultList)
        {
            StartCoroutine(CreatePointsInView(resultList));
        }

        IEnumerator CreatePointsInView(List<Vector2> resultList)
        {
            foreach (var position in resultList)
            {
                CreatePoint(position);
                yield return new WaitForSeconds(.3f);
            }

            _logic.CalculateMatgin();
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