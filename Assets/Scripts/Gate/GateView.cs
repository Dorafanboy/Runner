using TMPro;
using UnityEngine;

public class GateView : MonoBehaviour
{
    [SerializeField] private TMP_Text _changeCount;
    [SerializeField] private string _gateSign;

    public void Init(int runnerCount)
    {
        _changeCount.text = _gateSign + runnerCount;
    }
}
