using System.Runtime.Remoting.Messaging;


namespace Ben.DAL
{
    /// <summary>
    /// 数据库上下文工厂
    /// </summary>
    public class ContextFactory
    {
        /// <summary>
        /// 获取当前上下文
        /// </summary>
        /// <returns></returns>
        public static SofaContext GetCurrentContext()
        {
            //CallContext提供对每个逻辑执行线程都唯一的数据槽
            SofaContext _sContext = CallContext.GetData("SofaContext") as SofaContext;
            if (_sContext == null )
            {
                _sContext = new SofaContext();
                CallContext.SetData("SofaContext",_sContext);
            }
            return _sContext;
        }
    }
}
