using System.Collections;
using UnityEngine;

public class ProcessManager : MonoBehaviour
{
    public AsteroidManager AsteroidManager;

    // TODO: Use queue instead?
    //private readonly List<Process> _processList = new List<Process>();
    private Process _currentProcess = null;
    private int processPointer = 0;

    void Awake()
    {
        //_processList.Clear();
        //_processList.Add(new SpawnWaveProcess(AsteroidManager, asteroids: 20));
        //_processList.Add(new WaitProcess(waitTime: 5f));
        //_processList.Add(new SpawnWaveProcess(AsteroidManager, asteroids: 50));

        var firstProcess = new SpawnWaveProcess(AsteroidManager, asteroids: 2);
        var lastProcess = firstProcess
            .Attach(new WaitProcess(waitTime: 1f))
            .Attach(new SpawnWaveProcess(AsteroidManager, asteroids: 3))
            .Attach(new WaitProcess(waitTime: 1f));
        lastProcess.Attach(firstProcess);

        _currentProcess = firstProcess;
    }

    //void Start()
    //{
    //    StartCoroutine(LoopProcesses());
    //}

    ///// <summary>
    ///// Gets the count of active processes. This does not count
    ///// the child processes of active processes.
    ///// </summary>
    //public int ProcessCount
    //{
    //    get { return _processList.Count; }
    //}

    ///// <summary>
    ///// Attaches a new active process.
    ///// </summary>        
    //public void Attach(Process process)
    //{
    //    _processList.Add(process);
    //}

    ///// <summary>
    ///// Sets the state of all active processes to aborted.
    ///// </summary>
    //public void AbortAll()
    //{
    //    foreach (Process process in _processList)
    //    {
    //        process.State = ProcessState.Aborted;
    //    }
    //}

    /// <summary>
    /// Updates all the active processes.
    /// </summary>
    /// <returns>Number of succeeded and failed processes.</returns>
    private void FixedUpdate()
    {
        // Process is uninitialized, so initialize it.
        if (_currentProcess.State == ProcessState.Uninitialized)
        {
            _currentProcess.OnInit();
        }

        // Update the process, if it is running.
        if (_currentProcess.State == ProcessState.Running)
        {
            _currentProcess.OnUpdate(Time.fixedDeltaTime);
        }

        if (_currentProcess.IsDead)
        {
            switch (_currentProcess.State)
            {
                case ProcessState.Succeeded:
                    _currentProcess.OnSuccess();
                    //IEnumerable<Process> children = _currentProcess.PeekChildren();
                    //if (children != null)
                    //{
                    //    foreach (Process child in children)
                    //    {
                    //        Attach(child);
                    //        child.OnAttach();
                    //    }
                    //}
                    break;

                case ProcessState.Failed:
                    _currentProcess.OnFail();
                    break;

                case ProcessState.Aborted:
                    _currentProcess.OnAbort();
                    break;
            }

            _currentProcess = _currentProcess.Next();
        }
    }

}
