using System.Collections.Generic;

namespace DigitalBank.Api.Adm.Transaction.Business.Pagination
{
    public class PagedResultBase<T>
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public List<T> Result { get; set; }
    }
}
