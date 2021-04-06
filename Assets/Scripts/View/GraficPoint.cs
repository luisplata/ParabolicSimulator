using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace View
{
    public class GraficPoint : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coordinates;

        public void AssignCorrdinatesInView(float x, float y)
        {
            var vector = ConverUiUnit2NormalUnits(x, y);

            //formateo
            var sstring = $"{vector.x.ToString()},{vector.y.ToString()}";
            
            coordinates.text = sstring;
        }

        private Vector2 ConverUiUnit2NormalUnits(float x, float y)
        {
            x /= 100;
            y /= 100;
            x *= 2;
            y *= 2;
            return new Vector2(x,y);
        }
    }
}
