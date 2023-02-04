using System;
using UnityEngine;
using NoSurrenderCase.Game;
using UnityEngine.EventSystems;

public class PowerUp : MonoBehaviour
{
    public event EventHandler OnScaleUpGatheredEvent;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        Destroy(this.gameObject);
        OnScaleUpGatheredEvent?.Invoke(this, EventArgs.Empty);
    }
}
