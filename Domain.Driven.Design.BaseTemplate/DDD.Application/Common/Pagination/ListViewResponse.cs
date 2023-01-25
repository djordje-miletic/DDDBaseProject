namespace DDD.Application.Common.Pagination
{
    public class ListViewResponse<T>
    {
        public ListViewResponse(int? skip, int? top, int totalCount, IEnumerable<T> items)
        {
            this.Skip = skip ?? 0;
            this.Top = top ?? totalCount;
            this.TotalCount = totalCount;
            this.Items = items ?? new List<T>();
        }

        public int Skip { get; set; }
        public int? Top { get; set; }
        public int TotalCount { get; set; }
        public bool HasMoreResult => this.Skip + this.Top < this.TotalCount;
        public IEnumerable<T> Items { get; set; }
    }
}
