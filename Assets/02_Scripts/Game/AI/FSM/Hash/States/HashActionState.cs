namespace FSM.Hash
{

    /// <summary>
    /// 상태 전환을 Transition이 아닌 State에서 하는 녀석들
    /// </summary>
    // :: EX 단발성 엑션을 가진 녀석들
    public abstract class HashActionState : HashStateBase, IHashControllerUse
    {
        public IFSMController<int> Controller { get; private set; }
        public void SetController(IFSMController<int> controller)
        {
            Controller = controller;
        }

        public void ChangeState(int state) => Controller.ChangeState(state);

    }

}