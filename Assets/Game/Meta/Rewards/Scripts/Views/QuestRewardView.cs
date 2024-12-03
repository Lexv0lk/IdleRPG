using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Meta.Rewards
{
    public class QuestRewardView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _value;

        public void Initialize(ResourceRewardViewPresenter presenter)
        {
            _icon.sprite = presenter.Icon;
            _value.text = presenter.Value;
        }
    }
}