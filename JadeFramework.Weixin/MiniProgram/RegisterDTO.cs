namespace JadeFramework.Weixin.MiniProgram
{
    public class RegisterDTO
    {
        public string Code { get; set; }
        public string RawData { get; set; }
    }
    public class RegisterUserModel
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 用户所在国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 用户所在的省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public byte Gender { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarUrl { get; set; }
    }
}
