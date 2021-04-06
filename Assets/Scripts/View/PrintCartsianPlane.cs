using UnityEngine;

namespace View
{
    public class PrintCartsianPlane : MonoBehaviour
    {
        [SerializeField] private GameObject point;

        [SerializeField] private int scale;
        // Start is called before the first frame update
        void Start()
        {
            CreateCartesianPlane();
        }

        private void CreateCartesianPlane()
        {
            var scaleUi = scale * 10;
            var ratioSpawn = scale / 2;
            for (var i = 0; i < scaleUi; i += ratioSpawn)
            {
                var positionX = i;
                for (var j = 0; j < scaleUi; j += ratioSpawn)
                {
                    var positionY = j;
                    var pointInstantiate = Instantiate(this.point, transform);
                    pointInstantiate.GetComponent<GraficPoint>().AssignCorrdinatesInView(positionX, positionY);
                    pointInstantiate.transform.localPosition = new Vector2(positionX, positionY);
                }
            }
        }
    }
}
