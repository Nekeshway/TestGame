using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PizzaCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _pizzaValue;

    public void addValue(int value)
    {
        _pizzaValue += value;
        _text.text = _pizzaValue.ToString();
    }
}
