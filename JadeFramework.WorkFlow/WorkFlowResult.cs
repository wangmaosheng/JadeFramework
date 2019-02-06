namespace JadeFramework.WorkFlow
{
    /// <summary>
    /// 工作流返回结果
    /// </summary>
    public class WorkFlowResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static WorkFlowResult Success()
        {
            return new WorkFlowResult()
            {
                Result = true,
                Message = null,
                Data = null
            };
        }

        public static WorkFlowResult Success(string message)
        {
            return new WorkFlowResult()
            {
                Result = true,
                Message = message,
                Data = null
            };
        }
        public static WorkFlowResult Success(string message, object data)
        {
            return new WorkFlowResult()
            {
                Result = true,
                Message = message,
                Data = data
            };
        }
        public static WorkFlowResult Error(string message)
        {
            return new WorkFlowResult()
            {
                Result = false,
                Message = message,
                Data = null
            };
        }
        public static WorkFlowResult Error(string message, object data)
        {
            return new WorkFlowResult()
            {
                Result = false,
                Message = message,
                Data = data
            };
        }
    }
}
