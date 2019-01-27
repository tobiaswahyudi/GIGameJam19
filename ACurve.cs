using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACurve : MonoBehaviour
{
    public AnimationCurve ACx;
    public AnimationCurve ACy;
    public float periodX, periodY, amplitudeX, amplitudeY;
    private float elapsedTimeX, elapsedTimeY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTimeX += Time.deltaTime;
        elapsedTimeY += Time.deltaTime;
        if (elapsedTimeX > periodX) elapsedTimeX -= periodX;
        if (elapsedTimeY > periodY) elapsedTimeY -= periodY;
        this.transform.position = new Vector3(ACx.Evaluate(elapsedTimeX / periodX) * amplitudeX - 10, ACy.Evaluate(elapsedTimeY/periodY) * amplitudeY + 3.6f, 0.0f);
    }
}
