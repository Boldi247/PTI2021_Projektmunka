using UnityEngine;
using UnityEngine.UI;

public class Speed : MonoBehaviour
{
    public Text speedText;

    private void Update() {
        float speed = ControlCar.cc.carSpeed * 100;
        speedText.text = speed.ToString("0");
    }
}
