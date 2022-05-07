using System;

public class GameEvent<T>
{

	public static event Action<T> Global;
	public event Action<T> LocalEvent;
	public GameEvent() { }
	public GameEvent(Action<T> localEvent) => this.LocalEvent = localEvent;

	public static void GlobalInvoke() => Global?.Invoke(default);
	public void LocalInvoke() => LocalEvent?.Invoke(default);

}

public class GameEvent
{
	public static event Action GlobalEvent;
	public event Action LocalEvent;

	public GameEvent() { }
	public GameEvent(Action localEvent) => this.LocalEvent = localEvent;

	public static void GlobalInvoke() => GlobalEvent?.Invoke();
	public void LocalInvoke() => LocalEvent?.Invoke();

}
