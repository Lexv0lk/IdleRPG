using TMPro;
using UnityEngine;

namespace Game.Gameplay.Enemy
{
    public class NameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        
        public void Initialize(NameViewPresenter presenter)
        {
            _name.text = presenter.Name;
        }
    }
}