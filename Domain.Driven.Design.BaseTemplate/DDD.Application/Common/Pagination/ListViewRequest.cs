namespace DDD.Application.Common.Pagination
{
    public class ListViewRequest
    {
        private int skip;
        private int? top;

        public ListViewRequest()
        {
            this.skip = 0;
            this.top = null;
        }

        public int Skip
        {
            get => this.skip;
            set => this.skip =  value < 0 ? 0 : value;
        }

        public int? Top
        {
            get => this.top;
            set => this.top = value < 0 ? null : value;
        }

        public SortOrder Order { get; set; }

        public string? OrderBy { get; set; }
    }
}
