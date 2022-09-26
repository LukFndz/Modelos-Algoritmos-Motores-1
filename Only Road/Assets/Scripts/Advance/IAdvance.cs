using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAdvance
{
    void Advance();

    void ChangeVel(float newVel);

    float GetVelocity();
}
