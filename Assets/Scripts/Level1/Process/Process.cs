using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// Defines possible states for <see cref="Process"/>.
/// </summary>
public enum ProcessState
{
    /// <summary>
    /// Created but not running.
    /// </summary>
    Uninitialized,

    /// <summary>
    /// Removed from the process list but not destoryed. This can
    /// happen when a process that is already running is parented
    /// to another process.
    /// </summary>
    Removed,

    /// <summary>
    /// Initialized and running.
    /// </summary>
    Running,

    /// <summary>
    /// Initialized but paused.
    /// </summary>
    Paused,

    /// <summary>
    /// Completed successfully.
    /// </summary>        
    Succeeded,

    /// <summary>
    /// Failed to complete.
    /// </summary>
    Failed,

    /// <summary>
    /// Aborted. May not have started.
    /// </summary>
    Aborted
}

public abstract class Process
{
    private List<Process> _children;
    private ProcessState _previousState;

    /// <summary>
    /// Gets the <see cref="ProcessState"/>.
    /// </summary>
    public ProcessState State { get; set; }

    /// <summary>
    /// Gets if the process is alive.
    /// </summary>
    public bool IsAlive
    {
        get
        {
            return State == ProcessState.Running ||
                   State == ProcessState.Paused;
        }
    }

    /// <summary>
    /// Gets if the process is dead.
    /// </summary>
    public bool IsDead
    {
        get
        {
            return State == ProcessState.Succeeded ||
                   State == ProcessState.Failed ||
                   State == ProcessState.Aborted;
        }
    }

    /// <summary>
    /// Gets if the process has been removed.
    /// </summary>
    public bool IsRemoved
    {
        get { return State == ProcessState.Removed; }
    }

    /// <summary>
    /// Gets if the process is paused.
    /// </summary>
    public bool IsPaused
    {
        get { return State == ProcessState.Paused; }
    }

    public virtual void OnAttach() { }

    /// <summary>
    /// Initializes the process.
    /// </summary>
    public virtual void OnInit()
    {
        Debug.WriteLine(GetType().Name + ".OnInit()");
        State = ProcessState.Running;
    }

    /// <summary>
    /// Updates the process.
    /// </summary>
    /// <param name="fixedDeltaTime"></param>
    public virtual void OnUpdate(float fixedDeltaTime) { }

    /// <summary>
    /// Runs logic if the process succeeds.
    /// </summary>
    public virtual void OnSuccess() { }

    /// <summary>
    /// Runs logic if the process fails.
    /// </summary>
    public virtual void OnFail() { }

    /// <summary>
    /// Runs logic if the process is aborted.
    /// </summary>
    public virtual void OnAbort() { }

    /// <summary>
    /// Succeeds the process. Sets state to succeeded.
    /// </summary>
    public virtual void Succeed()
    {
        State = ProcessState.Succeeded;
    }

    /// <summary>
    /// Resets the process and all of its children down the chain. Sets state to uninitialized.
    /// </summary>
    public virtual void Reset()
    {
        State = ProcessState.Uninitialized;
        if (_children != null)
        {
            foreach (Process child in _children)
                child.Reset();
        }
    }

    /// <summary>
    /// Fails the process. Sets state to failed.
    /// </summary>
    public virtual void Fail()
    {
        State = ProcessState.Failed;
    }

    /// <summary>
    /// Pauses the process. Sets state to paused.
    /// </summary>
    public virtual void Pause()
    {
        _previousState = State;
        State = ProcessState.Paused;
    }

    /// <summary>
    /// Unpauses the process. Sets state back to previous state.
    /// </summary>
    public virtual void Unpause()
    {
        State = _previousState;
    }

    /// <summary>
    /// Attaches a child process to this process. This child will be run once
    /// this process succeeds.
    /// </summary>   
    /// <returns>The attached children process.</returns>     
    public Process AttachChild(Process child)
    {
        if (_children == null)
            _children = new List<Process>();
        _children.Add(child);
        return child;
    }

    /// <summary>
    /// Removes and returns the child processes.
    /// </summary>                
    public IEnumerable<Process> RemoveChildren()
    {
        if (_children == null) 
            return null;

        List<Process> children = _children;
        _children = null;
        return children;
    }

    /// <summary>
    /// Returns but does not remove the child processes.
    /// </summary>                
    public IEnumerable<Process> PeekChildren()
    {
        if (_children == null) 
            return null;

        return _children;
    }

}
