using System;
using UnityEngine;

public abstract class BoolOperation : MonoBehaviour
{
	public InteractInfo info;
	public abstract void RunIf(Func<bool> condition);
}