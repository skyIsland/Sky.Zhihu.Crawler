namespace Sky.Zhihu.NewCrawler
{
    public class ZhiHuPager
    {        
        public class Rootobject
        {
            public Paging paging { get; set; }
            public Datum[] data { get; set; }
        }
        /// <summary>
        /// 分页信息
        /// </summary>
        public class Paging
        {
            /// <summary>
            /// 是否结束页
            /// </summary>
            public bool is_end { get; set; }
            /// <summary>
            /// 总记录数
            /// </summary>
            public int totals { get; set; }
            /// <summary>
            /// 上一页
            /// </summary>
            public string previous { get; set; }
            /// <summary>
            /// 是否开始页
            /// </summary>
            public bool is_start { get; set; }
            /// <summary>
            /// 下一页
            /// </summary>
            public string next { get; set; }
        }

        public class Datum
        {
            public Relationship relationship { get; set; }
            public string editable_content { get; set; }
            public object[] mark_infos { get; set; }
            public string excerpt { get; set; }
            public string collapsed_by { get; set; }
            public int created_time { get; set; }
            public int updated_time { get; set; }
            public int id { get; set; }
            public int voteup_count { get; set; }
            public Can_Comment can_comment { get; set; }
            public bool is_collapsed { get; set; }
            public Author author { get; set; }
            public string url { get; set; }
            public string comment_permission { get; set; }
            public Question question { get; set; }
            public Suggest_Edit suggest_edit { get; set; }
            public string content { get; set; }
            public int comment_count { get; set; }
            public string extras { get; set; }
            public string reshipment_settings { get; set; }
            public bool is_copyable { get; set; }
            public string type { get; set; }
            public string thumbnail { get; set; }
            public bool is_normal { get; set; }
        }
        /// <summary>
        /// 关系
        /// </summary>
        public class Relationship
        {
            public object[] upvoted_followees { get; set; }
            public bool is_author { get; set; }
            public bool is_nothelp { get; set; }
            public bool is_authorized { get; set; }
            public int voting { get; set; }
            public bool is_thanked { get; set; }
        }

        public class Can_Comment
        {
            public bool status { get; set; }
            public string reason { get; set; }
        }
        /// <summary>
        /// 作者信息
        /// </summary>
        public class Author
        {
            public string avatar_url_template { get; set; }
            public string type { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public int gender { get; set; }
            public string user_type { get; set; }
            public string url_token { get; set; }
            public bool is_advertiser { get; set; }
            public string avatar_url { get; set; }
            public bool is_org { get; set; }
            public string headline { get; set; }
            public object[] badge { get; set; }
            public string id { get; set; }
        }
        /// <summary>
        /// 问题
        /// </summary>
        public class Question
        {
            public string question_type { get; set; }
            public string title { get; set; }
            public string url { get; set; }
            public int created { get; set; }
            public string type { get; set; }
            public int id { get; set; }
            public int updated_time { get; set; }
        }

        public class Suggest_Edit
        {
            public bool status { get; set; }
            public string reason { get; set; }
            public string title { get; set; }
            public string url { get; set; }
            public Unnormal_Details unnormal_details { get; set; }
            public string tip { get; set; }
        }

        public class Unnormal_Details
        {
        }     
    }
}
