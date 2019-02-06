using System.IO;

namespace JadeFramework.Core.Security
{
    /// <summary>
    /// 验证码
    /// </summary>
    public interface IVerificationCode
    {
        MemoryStream Create(out string code, int numbers = 4);
    }
}
