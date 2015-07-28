public class WaitProcess : Process 
{
    private readonly float _waitTime;
    private float _waited;

    public WaitProcess(float waitTime)
    {
        _waitTime = waitTime;
    }

    public override void OnInit()
    {
        base.OnInit();
        _waited = 0;
    }

    public override void OnUpdate(float fixedDeltaTime)
    {
        base.OnUpdate(fixedDeltaTime);

        if (_waitTime <= _waited)
        {
            State = ProcessState.Succeeded;
        }
        else
        {
            _waited += fixedDeltaTime;            
        }
    }
}