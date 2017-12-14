using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.ZhiHuImage.Crawler.Models
{
    /// <summary>文件信息</summary>
    [Serializable]
    [DataObject]
    [Description("文件信息")]
    [BindTable("FilesInfo", Description = "文件信息", ConnName = "Conn", DbType = DatabaseType.SQLite)]
    public partial class FilesInfo : IFilesInfo
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "编号", "")]
        public Int32 ID { get { return _ID; } set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } } }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Name", "名称", "", Master = true)]
        public String Name { get { return _Name; } set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "")]
        public DateTime CreateTime { get { return _CreateTime; } set { if (OnPropertyChanging(__.CreateTime, value)) { _CreateTime = value; OnPropertyChanged(__.CreateTime); } } }

        private String _InfoID;
        /// <summary>唯一ID</summary>
        [DisplayName("唯一ID")]
        [Description("唯一ID")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("InfoID", "唯一ID", "")]
        public String InfoID { get { return _InfoID; } set { if (OnPropertyChanging(__.InfoID, value)) { _InfoID = value; OnPropertyChanged(__.InfoID); } } }

        private String _FilePath;
        /// <summary>文件路径</summary>
        [DisplayName("文件路径")]
        [Description("文件路径")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("FilePath", "文件路径", "")]
        public String FilePath { get { return _FilePath; } set { if (OnPropertyChanging(__.FilePath, value)) { _FilePath = value; OnPropertyChanged(__.FilePath); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.ID : return _ID;
                    case __.Name : return _Name;
                    case __.CreateTime : return _CreateTime;
                    case __.InfoID : return _InfoID;
                    case __.FilePath : return _FilePath;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.CreateTime : _CreateTime = Convert.ToDateTime(value); break;
                    case __.InfoID : _InfoID = Convert.ToString(value); break;
                    case __.FilePath : _FilePath = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得文件信息字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName(__.ID);

            /// <summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            /// <summary>唯一ID</summary>
            public static readonly Field InfoID = FindByName(__.InfoID);

            /// <summary>文件路径</summary>
            public static readonly Field FilePath = FindByName(__.FilePath);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得文件信息字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>名称</summary>
            public const String Name = "Name";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>唯一ID</summary>
            public const String InfoID = "InfoID";

            /// <summary>文件路径</summary>
            public const String FilePath = "FilePath";
        }
        #endregion
    }

    /// <summary>文件信息接口</summary>
    public partial interface IFilesInfo
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>唯一ID</summary>
        String InfoID { get; set; }

        /// <summary>文件路径</summary>
        String FilePath { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}