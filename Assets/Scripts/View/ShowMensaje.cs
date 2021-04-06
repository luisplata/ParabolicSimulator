using UnityEngine;
using  TMPro;

namespace View
{
    public class ShowMensaje : MonoBehaviour
    {

        [SerializeField] private Animator _animator;
        [SerializeField] private TextMeshProUGUI mesageUi; 

        public void ShowMesage(string mensage)
        {
            mesageUi.text = mensage;
            _animator.SetTrigger("show");
        }
    }
}