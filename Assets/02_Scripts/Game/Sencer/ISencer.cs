using System;

public interface ISencer
{

    public event Action EnterEvent;
    public event Action ExitEvent;
    public bool CheckSencing();

}